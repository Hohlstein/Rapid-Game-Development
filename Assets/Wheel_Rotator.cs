/*
Autor: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wheel_Rotator : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f,0f,0f); // Set the desired rotation speed in degrees per second in the Inspector
    public AudioSource audioplayer;
    public TriangleRotator triangle;
    private float prev_zRotation = 0;
    public float drag;

    public bool gave_result = true;
    public bool moving = false;
    private bool haptic_clicked = true;

    void Update()
    {
        // Rotate the object continuously in the specified rotation speed
        transform.Rotate(-1*rotationSpeed * Time.deltaTime);
        checkIfHaptic();
        slowdown();
        if (moving == false && gave_result == false){
            giveResult();
        }
    }

    private void giveResult(){
        gave_result = true;
        List<string> possible_results = new List<string> {"sound design","graphic design", "game design", "coding" };
        int result_index = (int)(getRotation() % 180)/45;
        Debug.Log(possible_results[result_index]);

    }

    private float getRotation(){
        return transform.rotation.eulerAngles.z;
    }

    private void changeRotationSpeed(float x){
        rotationSpeed = rotationSpeed + new Vector3(0,0,x);
    }

    public void Push(){
        int randomInt = Random.Range(400, 800);
        changeRotationSpeed(randomInt);
        moving = true;
        gave_result = false;
    }

    public void slowdown(){
        rotationSpeed = rotationSpeed*drag;
        if (rotationSpeed.z < 5){
            rotationSpeed.z = 0;
            moving = false;
        }
    }

    private void checkIfHaptic(){
        float zRotation = getRotation();
        
        if (zRotation % 45 < 2 || zRotation % 45 > 43 && rotationSpeed.z > 5){
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
