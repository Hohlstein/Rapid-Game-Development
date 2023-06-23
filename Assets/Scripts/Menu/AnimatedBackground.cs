using UnityEngine;
using UnityEngine.UI;

public class AnimatedBackground : MonoBehaviour
{
    public Sprite[] sprites;// ist ein Array von Sprites, das verwendet wird, um die Bilder für die Animation des Hintergrunds zu speichern.
    private Image image; //image ist eine Referenz auf das Image-Komponente des GameObjects, an dem dieses Skript angehängt ist.
    private int currentIndex = 0; //currentIndex ist ein Zähler, der den aktuellen Index des angezeigten Sprites in sprites speichert.

    private void Start()
    {
        Application.targetFrameRate = 60;//legt die Ziel-Framerate der Anwendung auf 60 Frames pro Sekunde fest, was eine flüssige Animation ermöglicht.
        image = GetComponent<Image>();
        ChangeSprite(currentIndex);// die Methode "ChangeSprite" wird aufgerufen, um den anfänglichen Sprite basierend auf currentIndex zu setzen.
    }

    private void Update()
    {
       
        currentIndex++; // currentIndex um eins erhöht.
        if (currentIndex >= sprites.Length)//Wenn currentIndex größer oder gleich der Länge des sprites-Arrays ist, wird currentIndex auf 0 zurückgesetzt
        {
            currentIndex = 0;
        }

        ChangeSprite(currentIndex); //Dann wird die Methode "ChangeSprite" mit dem aktualisierten currentIndex aufgerufen, um den nächsten Sprite zu setzen.
    }

    
    private void ChangeSprite(int index)
    {
        if (index >= 0 && index < sprites.Length) //Es wird überprüft, ob der Index innerhalb des gültigen Bereichs liegt.

        {
            image.sprite = sprites[index];//Wenn ja, wird das entsprechende Sprite aus dem sprites-Array dem Image-Komponente zugewiesen.

        }
        else
        {
            Debug.LogError("Invalid index!");
        }
    }
}
