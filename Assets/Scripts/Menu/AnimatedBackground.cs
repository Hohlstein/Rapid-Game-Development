using UnityEngine;
using UnityEngine.UI;

public class AnimatedBackground : MonoBehaviour
{
    public Sprite[] sprites;// ist ein Array von Sprites, das verwendet wird, um die Bilder f�r die Animation des Hintergrunds zu speichern.
    private Image image; //image ist eine Referenz auf das Image-Komponente des GameObjects, an dem dieses Skript angeh�ngt ist.
    private int currentIndex = 0; //currentIndex ist ein Z�hler, der den aktuellen Index des angezeigten Sprites in sprites speichert.

    private void Start()
    {
        Application.targetFrameRate = 60;//legt die Ziel-Framerate der Anwendung auf 60 Frames pro Sekunde fest, was eine fl�ssige Animation erm�glicht.
        image = GetComponent<Image>();
        ChangeSprite(currentIndex);// die Methode "ChangeSprite" wird aufgerufen, um den anf�nglichen Sprite basierend auf currentIndex zu setzen.
    }

    private void Update()
    {
       
        currentIndex++; // currentIndex um eins erh�ht.
        if (currentIndex >= sprites.Length)//Wenn currentIndex gr��er oder gleich der L�nge des sprites-Arrays ist, wird currentIndex auf 0 zur�ckgesetzt
        {
            currentIndex = 0;
        }

        ChangeSprite(currentIndex); //Dann wird die Methode "ChangeSprite" mit dem aktualisierten currentIndex aufgerufen, um den n�chsten Sprite zu setzen.
    }

    
    private void ChangeSprite(int index)
    {
        if (index >= 0 && index < sprites.Length) //Es wird �berpr�ft, ob der Index innerhalb des g�ltigen Bereichs liegt.

        {
            image.sprite = sprites[index];//Wenn ja, wird das entsprechende Sprite aus dem sprites-Array dem Image-Komponente zugewiesen.

        }
        else
        {
            Debug.LogError("Invalid index!");
        }
    }
}
