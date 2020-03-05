using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraFade : MonoBehaviour
{
    //variables to handle fade switching
    public bool currentlyFading = false;
    public float fadingTime = 4.0f;


    public Image cameraFadeImage;
    public float fadeTimer = 3.0f;

    private Color fadeOpaque = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
    private Color fadeTransparent = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);

    void Start()
    {
        cameraFadeImage.color = fadeTransparent;
    }

    void timeSwitch()
    {
        StartCoroutine(fadeToColor(fadeOpaque, fadeTimer));
    }

    void Update()
    {
        //if the fading is currently not happening, the player can press T to start the fade. (conicides with Player Movement press T event)
        if (currentlyFading == false)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                timeSwitch();
                currentlyFading = true;
            }
        }

        if (currentlyFading == true)
        {
            if (fadingTime > 0)
            {
                fadingTime -= Time.deltaTime * 1f;           
            }
            else
            {
                StartCoroutine(fadeToColor(fadeTransparent, fadeTimer));
                currentlyFading = false;
                fadingTime = 4.0f;           
            }
        }

    }

    IEnumerator fadeToColor(Vector4 colorToFadeTo, float duration)
    {
        Color currentColor = cameraFadeImage.color;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
        {
            Color lerpColor = Color.Lerp(currentColor, colorToFadeTo, t);
            cameraFadeImage.color = lerpColor;
            yield return null;
        }
    }
}