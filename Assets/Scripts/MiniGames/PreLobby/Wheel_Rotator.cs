//Autor: Klaus Wiegmann

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Wheel_Rotator : MonoBehaviour
{
    public AudioSource audioplayer;
    public TriangleRotator triangle;
    public TextMeshProUGUI category_header;
    public Button button;
    public Container container;
    public GameObject ContainerDSP_obj;
    public GameObject introText_obj;
    public float friction = 0.999f;
    public AudioClip drumRollSound;
    public bool has_been_turned = false;
    public UIAudioPlayer UISounds;

    private Vector3 rotationSpeed = new Vector3(0f,0f,0f);
    private AudioSource audioSource;
    private Dictionary<int,string> mapping = new Dictionary<int, string>()
{
    //Die möglichen Drehwinkel müssen auf die resultierenden MiniGame Kategorien gemapped werden. Um mögliche Änderungen am Rad einfacher zu machen,
    //werden diese explizit definiert.
    { 0*43, "Sound Design" },
    { 1*43, "Graphic Design" },
    { 2*43, "Game Design" },
    { 3*43, "Coding" },
    { 4*43, "Sound Design" },
    { 5*43, "Graphic Design" },
    { 6*43, "Game Design" },
    { 7*43, "Coding" },
    { 8*43, "Special" },
};
    
    private bool gave_result = true;
    private bool moving = false;
    private bool haptic_clicked = true;

    void Start(){
        //Anfangs wird das Rad auf einen zufälligen Winkel gedreht und die Resultat Anzeige deaktiviert, dafür jedoch der kleine Text, der dem Spieler
        //erklärt, dass er auf das Rad klicken muss, aktiviert.
        SetRotationRandomly();
        ContainerDSP_obj.SetActive(false);
        introText_obj.SetActive(true);
    }

    void Update()
    {
        //Das Rad dreht sich immer um seine aktuelle Rotationsgeschwindigkeit.
        transform.Rotate(-1*rotationSpeed * Time.deltaTime);
        //Es muss überprüft werden, ob in diesem Frame einer der Feldränder der Kategorien überschritten wurde. Wenn ja, muss simuliert werden, dass das Dreieck anstößt.
        checkIfHaptic();
        slowdown();
        if (has_been_turned){
            //Falls das Rad gedreht wurde, darf es nicht nochmal anklickbar sein.
            button.enabled = false;
            //Falls das Rad gedreht wurde wird der Erklärungstext versteckt und stattdessen die aktuell angepeilte Kategorie rechts im Container angezeigt.
            category_header.text = computeResult();
            ContainerDSP_obj.SetActive(true);
            introText_obj.SetActive(false);
            if (moving == false && gave_result == false){
            //Falls sich das Rad nicht mehr dreht und das Ergebnis noch nicht übergeben wurde, wird dies getan.
                giveResult();
        }
        }
        else{
            button.enabled = true;
        }
        
    }

    private void SetRotationRandomly(){
        Quaternion currentRotation = transform.rotation;
        System.Random random = new System.Random();
        int newZRotation = random.Next(1, 360*5);
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, newZRotation);
        transform.rotation = newRotation;
    }

    private void giveResult(){
        //Der Trommelwirbel wird gestoppt und stattdessen ein Crashbecken und MIDI Strings abgespielt.
        audioSource.Stop();
        UISounds.TriggerSound(0);
        UISounds.TriggerSound(1);
        //gave_result wird auf true gesetzt, damit das Resultat nur einmal übergeben, bzw. die Sounds nur einmal abgespielt werden.
        gave_result = true;
        container.changeSprite(1);
        string result = computeResult();
        LuckResultDisplay display = ContainerDSP_obj.GetComponent<LuckResultDisplay>();
        display.ShowResult(result);
        

    }

    private string computeResult(){
        //Der relative Rotationswinkel wird berechnet (durch Modulo 360 liegt er im Bereich 0-359) und die dazu gemappete Kategorie zurückgegeben.
        int field = (int)getRotation()%360/43;
        return mapping[field*43];
    }

    private float getRotation(){
        return transform.rotation.eulerAngles.z;
    }

    private void changeRotationSpeed(float x){
        rotationSpeed = rotationSpeed + new Vector3(0,0,x);
    }

    public void Push(){
        if (has_been_turned == false){
            has_been_turned = true;
            //Das Rad wird angestuppst, mit einer zufälligen Rotationskraft. Hierdurch wird das Ergebnis nochmals zufällig gemacht, nachdem es bereits zu Beginn auf einen
            //zufälligen Ausgangswinkel gedreht wurde.
            int randomInt = Random.Range(620, 1500);
            changeRotationSpeed(randomInt);
            moving = true;
            StartDrumRoll();
            gave_result = false;
        }
    }

    public void slowdown(){
        //Das Rad muss mit der Zeit seine Rotationskraft verlieren. Außerdem wird überprüft, ob das Rad bereits beinahe angehalten hat (rotationSpeed.z < 2.)
        //Falls ja, wird es ganz angehalten, da bei so niedriger Rotationsgeschwindigkeit sowieso kaum noch eine Bewegung wahrgenommen wird.
        rotationSpeed = rotationSpeed*friction;
        if (rotationSpeed.z < 2){
            rotationSpeed.z = 0;
            moving = false;
        }
    }

    private void checkIfHaptic(){
        float zRotation = getRotation();
        
        //Falls der aktuelle Rotationswinkel 2° über oder unter einem Vielfachen von 43 liegt, liegt das Dreieck zurzeit nah an einem der Feldränder an.
        //In diesem Fall wird ein Klick Geräusch abgespielt und das Rad leicht abgebremst. Um sicher zu gehen, dass dies nur einmal pro Feldrand geschieht,
        //wird haptic_clicked auf true gesetzt und erst wieder auf false gesetzt, wenn der Bereich um den Feldrand wieder verlassen wurde.
        if (zRotation % 43 < 2 || zRotation % 43 > 41 && rotationSpeed.z > 5){
            if (haptic_clicked == false){
                haptic_clicked = true;
                audioplayer.Play();
                changeRotationSpeed(-5);
                triangle.flip(rotationSpeed.z);

            }
            
        }
        else{
            haptic_clicked = false;
        }
    }

    private void StartDrumRoll(){
        GameObject audioObject = new GameObject("UIAudioPlayer");
        DontDestroyOnLoad(audioObject);
        audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = drumRollSound;
        audioSource.Play();
    }

}
