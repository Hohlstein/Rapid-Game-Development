using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGame_Incorrect : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
    }

    // Update is called once per frame
    public void Flash(){
      StartCoroutine(FlashText());
    }

    IEnumerator FlashText()
    {
        int flashes = 3;
        int flashCount = 0;
        float delay = 0.2f;

        while (flashCount < flashes)
        {
            text.enabled = true;
            yield return new WaitForSeconds(delay);

            text.enabled = false;
            yield return new WaitForSeconds(delay);

            flashCount++;
        }

    }
}
