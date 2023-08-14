using UnityEngine;
using System.Collections;

public class InfoBox_Animation : MonoBehaviour
{
    public Transparency_Manager shadingTransparencyManager;
    public float targetSize = 2.0f;
    public float maxTransparency = 1.0f;

    public void FadeUp()
    {
        Vector3 initialScale = new Vector2(0.0f,0.0f);
        Vector3 targetScale = new Vector3(targetSize, targetSize, 1f);
        float duration = 0.6f;
        StartCoroutine(GrowAndSetTransparency(initialScale,targetScale, duration, false, new GameObject()));
    }

    public void FadeDownWithDestroy(GameObject obj_to_destroy)
    {
        Vector3 initialScale = new Vector3(targetSize, targetSize, 1f);
        Vector3 targetScale = new Vector2(0.0f,0.0f);
        float duration = 0.4f;
        StartCoroutine(GrowAndSetTransparency(initialScale,targetScale, duration, true, obj_to_destroy));
    }

    private IEnumerator GrowAndSetTransparency(Vector3 initialScale,Vector3 targetScale, float growthDuration, bool destroyObj, GameObject obj_to_destroy)
    {
        

        float elapsedTime = 0f;

        while (elapsedTime < growthDuration)
        {
            // Calculate the t value (0 to 1) based on elapsed time and growth duration
            float t = elapsedTime / growthDuration;

            // Use a custom ease-in-out function to modify t (e.g., easeInOut function)
            t = EaseInOut(t);

            // Interpolate the scale using the modified t value
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);

            // Update the transparency based on the current scale of the InfoBox
            float currentScaleFactor = transform.localScale.x / targetSize;
            shadingTransparencyManager.SetTransparency(currentScaleFactor*maxTransparency);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the InfoBox is at the target scale and set the final transparency
        transform.localScale = targetScale;
        shadingTransparencyManager.SetTransparency(maxTransparency);
        if (destroyObj){
            Destroy(obj_to_destroy);
        }
    }

    // Custom ease-in-out function (You can use other easing functions as needed)
    private float EaseInOut(float t)
    {
        // The following is an example of an ease-in-out function (smooth start and end)
        float k = 10f;
        float result = 1.0f / (1.0f + Mathf.Exp(-k * (t - 0.5f)));
        return result;
    }
}
