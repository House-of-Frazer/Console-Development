using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject topDownCamera;

    public static bool mainCamActive;
    //main camera is the player camera
    public bool past = false;

    void Start()
    {
        mainCamera.SetActive(true);
        topDownCamera.SetActive(false);
        mainCamActive = true;
    }

   void Update()
    {
        if(Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Joystick1Button5))
        {if (past == false)
            {
                past = true;
            }
        if(past == true)
            {
               past = false;
            }
        }
        //FBOne?
        if (past == true)
        {
            if (Input.GetKey(KeyCode.Y))
            {
                mainCamera.SetActive(false);
                topDownCamera.SetActive(true);
                mainCamActive = false;
            }
            if (Input.GetKey(KeyCode.Joystick1Button2))
            {
                mainCamera.SetActive(false);
                topDownCamera.SetActive(true);
                mainCamActive = false;
            }
            //FBTwo
            if (Input.GetKey(KeyCode.Joystick1Button1))
            {
                mainCamera.SetActive(true);
                topDownCamera.SetActive(false);
                mainCamActive = true;
            }
            if (Input.GetKey(KeyCode.R))
            {
                mainCamera.SetActive(true);
                topDownCamera.SetActive(false);
                mainCamActive = true;
            }
        }
    }
}