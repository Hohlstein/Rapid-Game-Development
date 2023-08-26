using UnityEngine;

public class Line : MonoBehaviour
{

    Vector3 startPos;
    Vector3 endpos;
    Vector3 mousePos;
    Vector3 mouseDir;
    Camera cam;
    LineRenderer lr;
    public int maxLine = 15;
    public bool finish = false;
    bool _rightbox = false;
    public Transform a;


    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        cam = Camera.main;


    }

    void Update()
    {


        if (!this.finish)
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseDir = mousePos - gameObject.transform.position;
            mouseDir.z = 0f;
            mouseDir = mouseDir.normalized;

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.transform != null)
                {
                    if (hit.transform.name == this.name)
                    {

                        lr.enabled = true;
                        _rightbox = true;
                    }


                }
            }

            if (Input.GetMouseButton(0))
            {
                if (this._rightbox)
                {
                    startPos = gameObject.transform.position;
                    startPos.z = 0f;
                    lr.SetPosition(0, startPos);
                    endpos = mousePos;
                    endpos.z = 0f;
                    float capLenth = Mathf.Clamp(Vector2.Distance(startPos, endpos), 0, maxLine);
                    endpos = startPos + (mouseDir * capLenth);
                    lr.SetPosition(1, endpos);

                    if (Vector3.Distance(endpos, a.position) <= 0.8f)
                    {
                        endpos = a.position;
                        finish = true;
                        lr.SetPosition(1, endpos);


                    }
                }



            }

            if (Input.GetMouseButtonUp(0))
            {
                this._rightbox = false;
                if (!this.finish)
                {
                    lr.enabled = false;

                }
            }
        }


    }
}