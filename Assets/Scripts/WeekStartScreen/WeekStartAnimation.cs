using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeekStartAnimation : MonoBehaviour
{
    public TextMeshProUGUI WeekDisplay;
    public TextMeshProUGUI WeeksLeftDisplay;
    public SmoothMove weeksLeft_move;
    public int currentNumberOfWeeks;
    public int deadlineNumberOfWeeks;
    public RectTransform flagTransform;
    public RectTransform triangleTransform;
    public Image BlackOverlay;
    public Image flag;
    public Image triangle;
    public Image whiteStripe;
    public Image progressStripe;
    public UIAudioPlayer UISounds;

    private float TotalWidthFactor = 1;

    void Start(){
        GameObject week_teller = GameObject.Find("WeekInfo");
        if (week_teller != null){
            currentNumberOfWeeks = week_teller.GetComponent<Week>().getWeek();
        }
        triangle.enabled = false;
        flag.enabled = false;
        whiteStripe.enabled = false;
        progressStripe.enabled = false;
        weeksLeft_move.setTargetX(0+960);
        weeksLeft_move.setTargetY(155+540);
        weeksLeft_move.freeze = true;
        WeeksLeftDisplay.enabled = false;
        WeekDisplay.text = "Week "+currentNumberOfWeeks;
        int NumberOfWeeksLeft = (deadlineNumberOfWeeks-currentNumberOfWeeks);
        if (NumberOfWeeksLeft > 1){
            WeeksLeftDisplay.text = NumberOfWeeksLeft + " weeks left";
        }
        if (NumberOfWeeksLeft == 1){
            WeeksLeftDisplay.text = NumberOfWeeksLeft + " week left";
        }
        else{
            WeeksLeftDisplay.text = "Final week!";
        }
        StartAnimations();
        

    }

    private void StartAnimations(){
        StartCoroutine(FadeOverlay());
    }

    private System.Collections.IEnumerator ExtendStripeAndFlag(){
        float maxWidthFactor = 1f * TotalWidthFactor;
        float General_YShift = 0;
        float c = 0;
        float animationDuration = 1;
        float startTime = Time.time;
        float endTime = startTime + animationDuration;
        while (Time.time < endTime)
        {
            float timeSoFar = Time.time - startTime;
            float t = timeSoFar/animationDuration;
            c = t*90*Mathf.Deg2Rad;
            float sin_val = Mathf.Abs(Mathf.Sin(c));
            FlagSetPos(-434*maxWidthFactor+sin_val*868*maxWidthFactor,-105+General_YShift);
            WhiteStripeSetWidth(maxWidthFactor*sin_val*824);
            flag.enabled = true;
            whiteStripe.enabled = true;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(MoveTriangle(currentNumberOfWeeks));
    }
    private System.Collections.IEnumerator MoveTriangle(int weeks){
        triangle.enabled = true;
        progressStripe.enabled = true;
        float maxWidthFactor = (float)weeks/deadlineNumberOfWeeks*TotalWidthFactor;
        float General_YShift = 0;
        float c = 0;
        float animationDuration = 1f;
        float startTime = Time.time;
        float endTime = startTime + animationDuration;
        while (Time.time < endTime)
        {
            float timeSoFar = Time.time - startTime;
            float t = timeSoFar/animationDuration;
            c = t*90*Mathf.Deg2Rad;
            float sin_val = Mathf.Abs(Mathf.Sin(c));
            TriangleSetPos(-412+maxWidthFactor*sin_val*824,-105+General_YShift);
            ProgressStripeSetWidth(maxWidthFactor*sin_val*824);
            yield return null;
        }
        yield return new WaitForSeconds(0.75f);
        StartCoroutine(FlashTriangle());
        
    }

    private void FlagSetPos(float x, float y){
        flagTransform.position = new Vector2(x+960,y+540);
    }
    private void TriangleSetPos(float x, float y){
        triangleTransform.position = new Vector2(x+960,y+540);
    }

    private void WhiteStripeSetWidth(float w){
        Vector2 newScale = new Vector2(w,9);
        whiteStripe.rectTransform.sizeDelta = newScale;
    }
    private void ProgressStripeSetWidth(float w){
        Vector2 newScale = new Vector2(w,9);
        progressStripe.rectTransform.sizeDelta = newScale;
    }

    IEnumerator FlashTriangle()
    {
        int flashes = 3;
        int flashCount = 0;
        float delay = 0.2f;

        while (flashCount < flashes)
        {
            UISounds.TriggerSound(0);
            triangle.enabled = false;
            yield return new WaitForSeconds(delay);

            triangle.enabled = true;
            yield return new WaitForSeconds(delay);

            flashCount++;
        }
        yield return new WaitForSeconds(1f);
        Debug.Log("weeks: " + currentNumberOfWeeks);
        Debug.Log("Deadline: "+deadlineNumberOfWeeks);
        if (currentNumberOfWeeks >= deadlineNumberOfWeeks) {
            SceneManagement.changeScene("Endscreen");
            yield break;
        }
        SceneManagement.changeScene("Chat");
    }

    private System.Collections.IEnumerator FadeOverlay()
    {
        Color originalColor = BlackOverlay.color;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        float fadeDuration = 2f;
        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime = Time.time - startTime;
            float normalizedTime = elapsedTime / fadeDuration;
            Color lerpedColor = Color.Lerp(originalColor, targetColor, normalizedTime);
            BlackOverlay.color = lerpedColor;
            if (elapsedTime > fadeDuration/2){
                WeeksLeftDisplay.enabled = true;
                weeksLeft_move.freeze = false;
            }
            yield return null;
        }
        BlackOverlay.color = targetColor;
        StartCoroutine(ExtendStripeAndFlag());
    }

}
