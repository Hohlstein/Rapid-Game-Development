using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleRotator : MonoBehaviour
{
    public float flipAmount = 10f;
    public float returnAmout = 0.9f;

    public void flip(float speed){
        Quaternion currentRotation = transform.rotation;
        float newZ = flipAmount + Mathf.Min(speed,15f);
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, newZ);
        transform.rotation = newRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion currentRotation = transform.rotation;
        float z_rotation = currentRotation.eulerAngles.z;
        if (Mathf.Abs(z_rotation) > 60){
            if (z_rotation > 0){
                setZ(60f);
            }
            else{
                setZ(-60f);
            }
            
        }
        float newZ = z_rotation * returnAmout;
        setZ(newZ);
        
    }

    private void setZ(float newZ){
        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, newZ);
        transform.rotation = newRotation;
    }
}
