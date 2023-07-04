using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    float target_x;
    float target_y;
    float current_x;
    float current_y;
    public float friction;

    // Start is called before the first frame update
    void Start()
    {
        current_x = transform.position.x;
        current_y = transform.position.y;
        target_x = current_x;
        target_y = current_y;

    }

    // Update is called once per frame
    void Update()
    {
        getPos();
        float x_change = (target_x-current_x)/friction;
        float y_change = (target_y-current_y)/friction;
        doStep(x_change,y_change);
    }

    public void setTargetX(float x){
        target_x = x;
    }
    public void setTargetY(float y){
        target_y = y;
    }

    public void setCurrentX(float x){
        Vector3 newPosition = new Vector3(x, current_y);
        transform.position = newPosition;
    }
    public void setCurrentY(float y){
        Vector3 newPosition = new Vector3(current_x, y);
        transform.position = newPosition;
    }

    public void setFriction(float val){
        friction = val;
    }

    private void doStep(float x, float y){
        Vector3 newPosition = new Vector3(current_x + x, current_y + y);
        transform.position = newPosition;
    }

    private void getPos(){
        current_x = transform.position.x;
        current_y = transform.position.y;
    }
}
