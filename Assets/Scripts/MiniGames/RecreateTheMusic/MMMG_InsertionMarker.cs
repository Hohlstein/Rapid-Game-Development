using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MMMG_InsertionMarker : MonoBehaviour
{
    private int index;
    private int standard_x;
    private bool show;
    private Image image;
    public float X;
    private int tick;
    private Vector3 standard_scale;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        standard_x = 378;
        show = false;
        tick = 0;
        standard_scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        tick += 1;
        if (show){
            image.enabled = true;
            GoToPosition(index*(115.5f/2),0);  
            UpdateSize();        
        }
        else{
            image.enabled = false;
            tick = 0;
        }
    }

    void GoToPosition(float x, float y){
        Vector3 newPosition = new Vector3(x + standard_x, y+108, transform.position.z);
        transform.position = newPosition;
    }

    public void Hide(){
        show = false;
    }

    public void Show(){
        show = true;
    }

    public void SetIndex(int x){
        index = x;
    }

    private void UpdateSize(){
        float angleInRadians = Mathf.Deg2Rad * tick;
        float sinusValue = Mathf.Sin(angleInRadians);
        Vector3 currentScale = transform.localScale;
        Vector3 newScale = new Vector3(standard_scale.x, standard_scale.y + sinusValue*0.4f, currentScale.z);
        // Apply the new scale to the object
        transform.localScale = newScale;
    }
}
