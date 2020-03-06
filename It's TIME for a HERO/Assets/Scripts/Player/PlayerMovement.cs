using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody RB;
    public bool PlayerGrounded;

    public int moveSpeed;

    //test mesh swap
    public GameObject levelPast;
    public GameObject levelPresent;
    bool inPast = false;

    //bool to check whether player is time travelling
    public static bool timeTravel = false;
    public float travelTimer = 7.0f;

    //bool to handle level switching between past and present
    public bool switchLevel = true;
    public float switchTimer = 3.5f;

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
                    }
                    else
                    {
                        levelPast.SetActive(false);
                        levelPresent.SetActive(true);
                        inPast = false;
                        switchLevel = false;
                        switchTimer = 3.5f;
                    }
                }
            }
        }
    }

    public void Forward() //Controls for movement using W when the player presses and holds the key
    {
        transform.Translate((transform.forward * moveSpeed * Time.deltaTime), Space.World);        
    }

    public void Left() //Controls for movement using A when the player presses and holds the key
    {
        transform.Translate(Vector3.left * Time.deltaTime, Camera.main.transform);
    }
    public void Right() //Controls for movement using S when the player presses and holds the key
    {
        transform.Translate(Vector3.right * Time.deltaTime, Camera.main.transform);
    }
    public void Backward() //Controls for movement using D when the player presses and holds the key
    {
        transform.Translate((-transform.forward * Time.deltaTime * Time.deltaTime), Space.World);
    }

    public void RotateLeft()  //Controls for movement of the players rotation using Q
    {
        transform.Rotate(-Vector3.up * 2);
    }

    public void RotateRight() //Controls for movement of the players rotation using E
    {
        transform.Rotate(Vector3.up * 2);   
    }


    public IEnumerator Jumping()
    {
        RB.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        PlayerGrounded = false;
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            PlayerGrounded = true;
        }
    }
}
