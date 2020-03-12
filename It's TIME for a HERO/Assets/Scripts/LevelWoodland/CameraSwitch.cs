using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject topDownCamera;

    public static bool mainCamActive;
    //main camera is the player camera

    void Start()
    {
        mainCamera.SetActive(true);
        topDownCamera.SetActive(false);
        mainCamActive = true;
    }

   void Update()
    {
        if (Input.GetButton("FBOne"))
        {
            //if (mainCamActive == true)
            //{
                mainCamera.SetActive(false);
                topDownCamera.SetActive(true);
                mainCamActive = false;
            //}
            /*if (mainCamActive == false)
            {
                mainCamera.SetActive(true);
                topDownCamera.SetActive(false);
                mainCamActive = true;
            }*/
       
        }
        if (Input.GetButton("FBTwo"))
        {
            mainCamera.SetActive(true);
            topDownCamera.SetActive(false);
            mainCamActive = true;
        }
    }
}