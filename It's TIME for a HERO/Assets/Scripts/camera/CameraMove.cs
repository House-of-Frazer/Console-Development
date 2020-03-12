using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    //public Transform Player;
    public Camera FirstPersonCam, ThirdPersonCam;
    public KeyCode TKey;
    public bool camSwitch = false;
    public GameObject shoptext;

    void Start()
    {
        shoptext.SetActive(false);
}

    void Update()
    {
        if (Input.GetKeyDown(TKey))
        {
            camSwitch = !camSwitch;
            FirstPersonCam.gameObject.SetActive(camSwitch);
            ThirdPersonCam.gameObject.SetActive(!camSwitch);
            shoptext.gameObject.SetActive(true);
        }
    }
}
