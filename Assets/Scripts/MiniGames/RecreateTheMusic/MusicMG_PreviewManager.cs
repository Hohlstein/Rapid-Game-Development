//Autor:Klaus Wiegmann

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMG_PreviewManager : MonoBehaviour
{
    private List<MusicSample_Main> placed_samples;
    public List<MusicSample_Main> all_samples;
    public MMMG_InsertionMarker marker;
    public float ExtraPadding;

    public void Start()
    {
        placed_samples = new List<MusicSample_Main>();

    }

    public void Update(){
        if (GetSamplesToInsert() != null){
            //sample ist nun das Sample, welches gerade vom Spieler übers Feld gehalten wird.
            MusicSample_Main sample = GetSamplesToInsert();
            int insertion_index = CalcInsertionIndex(sample);
            int marker_index = 2 * GetMarkerIndexForSampleIndex(insertion_index);
            marker.Show();
            marker.SetIndex(marker_index);
            //Die X-Position aller Samples wird aktualisiert, abhängig vom angepeilten Index und der Breite des aktuell übers Feld gehaltenen Sample Objekts.   
            UpdatePlacedSamplePositions(true,insertion_index,sample.GetPixelWidth());
            
        }
        else{
            //Falls aktuell kein Sample übers Feld gehalten wird, verschwindet der Marker. Alle bisher platzierten Samples werden dennoch auf die richtige X-Position aktualisiert,
            //wobei ihnen über "false" mitgeilt wird, dass aktuell kein neues Sample über das Feld gehalten wird.
            marker.Hide();
            UpdatePlacedSamplePositions(false,0,0);
        }
        
    }

    public void RegisterSample(MusicSample_Main sample){
        all_samples.Add(sample);
    }

    private MusicSample_Main GetSamplesToInsert(){
        //Überprüft für alle Sample Objekte, ob sie gerade über das Feld gehalten werden. Kann eigentlich nur bei einem der Fall sein (da der Spieler nur eins gleichzeitig
        //ziehen kann), daher wird nur ein Objekt zurückgegeben.
        for (int i = 0; i < all_samples.Count; i++)
        {
            if (all_samples[i].checkIfInBoxReach()){
                return all_samples[i];
            }
        }
        return null;
    }

    private int CalcInsertionIndex(MusicSample_Main sample){
        //Es wird berechnet, auf welchen Index der Spieler das aktuelle Sample anpeilt. Sind noch keine Samples im Feld, wird immer Index 0 angepeilt.
        float hover_x = sample.getXPosition();
        for (int i = placed_samples.Count -1; i >= 0; i = i-1)
        //Falls doch, wird für jedes existierende Sample (von hinten nach vorne) überprüft, ob dessen X-Position über dem des vom Spieler gehaltenen Samples liegt.
        //Falls ja, liegt der angepeilte Index genau eins höher als der dieses Samples. 
        {
            if (hover_x > placed_samples[i].getXPosition()){
                return i+1;
            }
        }
        return 0;
    }

    public void DropSample(MusicSample_Main sample){
        //Wird ein neues Sample ins Feld platziert, wird es in die placed_samples Liste am angepeilten Index hinzugefügt. Hierdurch verschieben sich, falls
        //das Sample nicht ans Ende gefügt wurde, alle anderen Samples automatisch nach rechts, dass sich ihr Index erhöht.
        int insertion_index = CalcInsertionIndex(sample);
        placed_samples.Insert(insertion_index,sample);
        sample.setTargetX(sample.GetPixelWidth()/2 + GetWidthUpUntilSampleIndex(insertion_index));
        sample.setTargetY(108);

    }

    private float GetWidthUpUntilSampleIndex(int index){
        //Es wird berechnet, wie breit die bisher platzierten Samples bis zu einem bestimmten Index in Pixeln sind.
        float output = 0;
        for (int i = 0; i < index; i++)
        {
            output += placed_samples[i].GetPixelWidth()-2;
        }
        return output;
    }

    private int GetMarkerIndexForSampleIndex(int index){
        //Hier wird der Index für das Marker berechnet, damit es am richtigen Platz erscheint. Hierzu müssen die MarkerIndexSpacings von allen Samples bis zum aktuell
        //angepeilten Index addiert werden. Diese sind für kurze Samples 1, für lange 2.
        int output = 0;
        for (int i = 0; i < index; i++)
        {
            output += placed_samples[i].GetMarkerIndexSpacing();
        }
        return output;
    }


    private void UpdatePlacedSamplePositions(bool inserting, int insertion_index, float extra_space){
        //Für jedes Sample Objekt wird die richtige X-Koordinate am laufenden Band aktualisiert.
        for (int i = 0; i < placed_samples.Count; i++)
        {
            MusicSample_Main sample = placed_samples[i];
            ExtraPadding = 3;
            float calculated_x = (376) + sample.GetPixelWidth()/2 + GetWidthUpUntilSampleIndex(i) + ExtraPadding*i;
            if (inserting && i >= insertion_index){
                //Wird gerade ein neues Sample über dem Feld gehalten und befindet sich der temporär angepeilte Index dieses einzufügenden Samples vor dem des aktuellen Samples,
                //muss das Sample ein Stück (extra_space) nach rechts gedrückt werden. So machen alle anderen Samples temporär Platz, wenn ein neues eingefügt werden soll.
                calculated_x += extra_space;
            }
            sample.setTargetX(calculated_x);
        }
    }

    public void RemoveSample(MusicSample_Main sample){
        //Ein sample kann aus der placed_samples Liste einfach wieder entfernt werden.
        for (int i = 0; i < placed_samples.Count; i++)
        {
            if (placed_samples[i] == sample){
                placed_samples.RemoveAt(i);
                break;
            }
        }
    }

    public List<MusicSample_Main> GetSampleList(){
        return placed_samples;
    }

    public int GetNumberOfPlacedSamples(){
        return placed_samples.Count;
    }

}

