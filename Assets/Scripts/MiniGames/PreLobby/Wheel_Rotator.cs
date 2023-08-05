/*
Autor: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Wheel_Rotator : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f,0f,0f); // Set the desired rotation speed in degrees per second in the Inspector
    public AudioSource audioplayer;
    public TriangleRotator triangle;
    public TextMeshProUGUI category_header;
    public Button button;
    public Container container;
    public GameObject ContainerDSP_obj;
    public GameObject introText_obj;
    public float drag;
    public bool has_been_turned = false;

    private Dictionary<int,string> mapping = new Dictionary<int, string>()
{
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
        SetRotationRandomly();
        ContainerDSP_obj.SetActive(false);
        introText_obj.SetActive(true);
    }

    void Update()
    {
        // Rotate the object continuously in the specified rotation speed
        transform.Rotate(-1*rotationSpeed * Time.deltaTime);
        checkIfHaptic();
        slowdown();
        if (has_been_turned){
            button.enabled = false;
            category_header.text = computeResult();
            ContainerDSP_obj.SetActive(true);
            introText_obj.SetActive(false);
        }
        else{
            button.enabled = true;
        }
        if (moving == false && gave_result == false){
            giveResult();
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
        gave_result = true;
        container.changeSprite(1);
        string result = computeResult();
        LuckResultDisplay display = ContainerDSP_obj.GetComponent<LuckResultDisplay>();
        display.ShowResult(result);
        

    }

    private string computeResult(){
        int field = (int)getRotation()%360/43;
        return mapping[field*43];
        //return possible_results[result_index];
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
            int randomInt = Random.Range(400, 800);
            changeRotationSpeed(randomInt);
            moving = true;
            gave_result = false;
        }
    }

    public void slowdown(){
        rotationSpeed = rotationSpeed*drag;
        if (rotationSpeed.z < 2){
            rotationSpeed.z = 0;
            moving = false;
        }
    }

    private void checkIfHaptic(){
        float zRotation = getRotation();
        
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

}
