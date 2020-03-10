using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject topDownCamera;

    public bool mainCamActive;

    void Start()
    {
        mainCamera.SetActive(true);
        topDownCamera.SetActive(false);
        mainCamActive = true;
    }

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            mainCamera.SetActive(true);
            topDownCamera.SetActive(false);
            mainCamActive = true;
        }
    }
}