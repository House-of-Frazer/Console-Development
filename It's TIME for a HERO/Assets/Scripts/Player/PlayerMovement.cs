﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody RB;
    bool PlayerGrounded;

    public int moveSpeed;


    //test mesh swap
    public GameObject levelPast;
    public GameObject levelPresent;
    bool inPast = false;

    // Start is called before the first frame update
    void Start()
    {
        levelPast.SetActive(false);
        levelPresent.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //requires the player to press space to jump
        if (Input.GetKeyDown(KeyCode.Space) && PlayerGrounded)
        {
            StartCoroutine(Jumping());
        }

        //test mesh swap
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (inPast == false)
            {
                levelPast.SetActive(true);
                levelPresent.SetActive(false);
                inPast = true;
            }
            else
            {
                levelPast.SetActive(false);
                levelPresent.SetActive(true);
                inPast = false;
            }
        }

        //Controles for movement using WASD when the player presses and holds the key
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate((transform.forward * moveSpeed * Time.deltaTime), Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime, Camera.main.transform);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((-transform.forward * moveSpeed * Time.deltaTime), Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime, Camera.main.transform);
        }

        //Controls for movement of the players rotation using Q and E keys to look around and behind themselves
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * 2);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(-Vector3.up * 2);
        }

    }

    IEnumerator Jumping()
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
