/*
Autor: Klaus Wiegmann
*/

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
            MusicSample_Main sample = GetSamplesToInsert();
            int insertion_index = CalcInsertionIndex(sample);
            int marker_index = 2 * GetMarkerIndexForSampleIndex(insertion_index);
            marker.Show();
            marker.SetIndex(marker_index);
            UpdatePlacedSamplePositions(true,insertion_index,sample.GetPixelWidth());
            
        }
        else{
            marker.Hide();
            UpdatePlacedSamplePositions(false,0,0);
        }
        
    }

    public void RegisterSample(MusicSample_Main sample){
        all_samples.Add(sample);
    }

    private MusicSample_Main GetSamplesToInsert(){
        for (int i = 0; i < all_samples.Count; i++)
        {
            if (all_samples[i].checkIfInBoxReach()){
                return all_samples[i];
            }
        }
        return null;
    }

    private int CalcInsertionIndex(MusicSample_Main sample){
        float hover_x = sample.getXPosition();
        for (int i = placed_samples.Count -1; i >= 0; i = i-1)
        {
            if (hover_x > placed_samples[i].getXPosition()){
                return i+1;
            }
        }
        return 0;
    }

    public void DropSample(MusicSample_Main sample){
        int insertion_index = CalcInsertionIndex(sample);
        placed_samples.Insert(insertion_index,sample);
        sample.setTargetX(378 + sample.GetPixelWidth()/2 + GetWidthUpUntilSampleIndex(insertion_index));
        sample.setTargetY(108);

    }

    private float GetWidthUpUntilSampleIndex(int index){
        float output = 0;
        for (int i = 0; i < index; i++)
        {
            output += placed_samples[i].GetPixelWidth();
        }
        return output;
    }

    private int GetMarkerIndexForSampleIndex(int index){
        int output = 0;
        for (int i = 0; i < index; i++)
        {
            output += placed_samples[i].GetMarkerIndexSpacing();
        }
        return output;
    }


    private void UpdatePlacedSamplePositions(bool inserting, int insertion_index, float extra_space){
        for (int i = 0; i < placed_samples.Count; i++)
        {
            MusicSample_Main sample = placed_samples[i];
            ExtraPadding = 3;
            float calculated_x = (376) + sample.GetPixelWidth()/2 + GetWidthUpUntilSampleIndex(i) + ExtraPadding*i;
            if (inserting && i >= insertion_index){
                calculated_x += extra_space;
            }
            sample.setTargetX(calculated_x);
        }
    }

    public void RemoveSample(MusicSample_Main sample){
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

