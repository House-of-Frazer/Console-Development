using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTravel : MonoBehaviour
{
    public Rigidbody RB;
    public bool PlayerGrounded;

    //test mesh swap
    public GameObject levelPast;
    public GameObject levelPresent;
    public bool inPast = false;

    //bool to check whether player is time travelling
    public static bool timeTravel = false;
    public float travelTimer = 7.0f;

    //bool to handle level switching between past and present
    public bool switchLevel = true;
    public float switchTimer = 3.5f;

    BackgroundMusic backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        levelPast.SetActive(false);
        levelPresent.SetActive(true);
    }

    void Update()
    {
        //timer to handle freezing player movement until time travel is complete
        if (timeTravel == true)
        {
            if (travelTimer > 0)
            {
                travelTimer -= Time.deltaTime * 1f;
                //while switch Level bool is true, count down switch Timer
                if (switchLevel == true)
                    switchTimer -= Time.deltaTime * 1f;
            }
            else
            {
                timeTravel = false;
                switchLevel = true;
                travelTimer = 7.0f;
            }

            //if the level can be switched and the switch timer is 0 or less, switch level
            if (switchLevel == true)
            {
                if (switchTimer <= 0)
                {
                    Debug.Log("switch level");
                    if (inPast == false)
                    {
                        levelPast.SetActive(true);
                        levelPresent.SetActive(false);
                        inPast = true;
                        switchLevel = false;
                        switchTimer = 3.5f;
                        backgroundMusic.MyFunctionCalled = false;

                    }
                    else
                    {
                        levelPast.SetActive(false);
                        levelPresent.SetActive(true);
                        inPast = false;
                        switchLevel = false;
                        switchTimer = 3.5f;
                        backgroundMusic.MyFunctionCalled = false;

                    }
                }
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            PlayerGrounded = true;
        }
    }


    void Awake()
    {
        backgroundMusic = GetComponent<BackgroundMusic>();
    }
}
