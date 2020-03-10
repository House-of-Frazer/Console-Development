using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraFade : MonoBehaviour
{
    PlayerMovementN checkGrounded; //Reference for the PlayerMovement script;

    //variables to handle fade switching
    public bool currentlyFading = false;
    public float fadingTime = 4.0f;

    //variable to control the total fade time, to prevent player activating time travel before fade in and out has completed
    bool totalFadeComplete = true;
    float totalFadeTime = 7.0f;


    public Image cameraFadeImage;
    public float fadeTimer = 3.0f;

    private Color fadeOpaque = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
    private Color fadeTransparent = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);

    void Start()
    {
        cameraFadeImage.color = fadeTransparent;
        checkGrounded = GetComponent<PlayerMovementN>(); //Setup reference for the PlayerMovement script;
    }

    void timeSwitch()
    {
        StartCoroutine(fadeToColor(fadeOpaque, fadeTimer));
    }

    void Update()
    {
        if (checkGrounded.PlayerGrounded == true)
        {
            //if the fading is currently not happening, the player can press T to start the fade. (conicides with Player Movement press T event)
            if (currentlyFading == false && totalFadeTime >= 7)
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    timeSwitch();
                    currentlyFading = true;
                    totalFadeComplete = false;
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

            if (totalFadeComplete == false)
            {
                totalFadeTime -= Time.deltaTime * 1f;
            }

            //reset total fade Time
            if (totalFadeTime <= 0)
            {
                totalFadeComplete = true;
                totalFadeTime = 7.0f;
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