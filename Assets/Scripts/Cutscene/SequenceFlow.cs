using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreenSequence : MonoBehaviour

{
    public TMP_Text Conclusion;
    public TMP_Text Good;
    public TMP_Text Or;
    public TMP_Text Bad;
    public TMP_Text Preparation;

    

    // Start is called before the first frame update
    IEnumerator Start()
    {   
        MakeAllInvisible();
        StartCoroutine(FadeTextIn(1f, Conclusion));
        yield return new WaitForSeconds(2);
        /*StartCoroutine(FadeImageIn(1f, picture1));
        yield return new WaitForSeconds(1);
        StartCoroutine(FadeImageIn(1f, picture2));
        yield return new WaitForSeconds(1);
        StartCoroutine(FadeImageIn(1f, picture3));
        yield return new WaitForSeconds(1);*/
        StartCoroutine(FadeTextIn(1f, Good));
        yield return new WaitForSeconds(2);
        StartCoroutine(FadeTextIn(1f, Or));
        yield return new WaitForSeconds(2);
        StartCoroutine(FadeTextIn(1f, Bad));
        yield return new WaitForSeconds(2);
        StartCoroutine(FadeTextIn(1f, Preparation));
        yield return new WaitForSeconds(2);
        SceneManagement.changeScene("Endscreen");
    }

    public IEnumerator FadeTextIn(float f, TMP_Text t)
    {
        
        t.color = new Color(t.color.r, t.color.g, t.color.b, 0);
        while (t.color.a < 1.0f)
        {
            Debug.Log("we are here" + t.color.a);
            t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a + (Time.deltaTime /f));
            yield return null;
        }
        yield return StartCoroutine(FadeTextOut(f, t));
    }
 
    public IEnumerator FadeTextOut(float f, TMP_Text t)
    {
        t.color = new Color(t.color.r, t.color.g, t.color.b, 1);
        while (t.color.a > 0.0f)
        {
            Debug.Log("Fading out" + t.color.a);
            t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a - (Time.deltaTime / f));
            yield return null;
        }
    }

    public IEnumerator FadeImageIn(float f, Image s)
    {
        
        s.color = new Color(s.color.r, s.color.g, s.color.b, 0);
        while (s.color.a < 1.0f)
        {
            
            s.color = new Color(s.color.r, s.color.g, s.color.b, s.color.a + (Time.deltaTime /f));
            yield return null;
        }
    }

    public void MakeAllInvisible() {
        Conclusion.color = new Color(Conclusion.color.r, Conclusion.color.g, Conclusion.color.b, 0);
        Good.color = new Color(Good.color.r, Good.color.g, Good.color.b, 0);
        Or.color = new Color(Or.color.r, Or.color.g, Or.color.b, 0);
        Bad.color = new Color(Bad.color.r, Bad.color.g, Bad.color.b, 0);
        Preparation.color = new Color(Preparation.color.r, Preparation.color.g, Preparation.color.b, 0);
        /*picture1.color = new Color(picture1.color.r, picture1.color.g, picture1.color.b, 0);
        picture2.color = new Color(picture2.color.r, picture2.color.g, picture2.color.b, 0);
        picture3.color = new Color(picture3.color.r, picture3.color.g, picture3.color.b, 0);*/
    }
}