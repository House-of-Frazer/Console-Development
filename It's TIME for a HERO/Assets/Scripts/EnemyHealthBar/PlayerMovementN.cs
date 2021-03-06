﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementN : MonoBehaviour
{
    public Rigidbody RB;
    public bool PlayerGrounded;
    public float movement = 0.1f;


    public Transform bulletspawner;
    public GameObject bulletprefab;
    public float bulletSpeed = 5.0f;
    public int lifetime = 3;
    bool shooting = true;


    public GameObject pivot;

    private Vector3 moveDirection;

    float axisHorizontal, axisVertical;

    public HealthUI healthUi;


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>(); //Setup reference for the PlayerMovement script;

        axisHorizontal = Input.GetAxis("Horizontal");
        axisVertical = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) || Input.GetButton("FBTwo"))
        {
            if (shooting)
            {
                GameObject bullet = Instantiate(bulletprefab);
                bullet.transform.position = bulletspawner.position;
                bullet.GetComponent<Rigidbody>().AddForce(bulletspawner.forward * bulletSpeed, ForceMode.Impulse);

                StartCoroutine(DestroyBullet(bullet, lifetime));
                shooting = false;
            }
        } 
    }

    public void takeDamaage()
    {
        healthUi.CurrentNumberofHearts -= 1;
        healthUi.ClearScreen();
    }

    public void Forward() //Controls for movement using W when the player presses and holds the key
    {
        transform.Translate(Vector3.forward * movement, pivot.transform);
        transform.Translate(Vector3.forward * axisVertical, pivot.transform);
    }

    public void Left() //Controls for movement using A when the player presses and holds the key
    {
        transform.Translate(Vector3.left * movement, pivot.transform);
        transform.Translate(Vector3.left * axisHorizontal, pivot.transform);
    }
    public void Right() //Controls for movement using S when the player presses and holds the key
    {
        transform.Translate(Vector3.right * movement, pivot.transform);
        transform.Translate(Vector3.right * axisHorizontal, pivot.transform);
    }
    public void Backward() //Controls for movement using D when the player presses and holds the key
    {
        transform.Translate(-Vector3.forward * movement, pivot.transform);
        transform.Translate(-Vector3.forward * axisVertical, pivot.transform);
    }

    public void RotateLeft()  //Controls for movement of the players rotation using Q
    {
        transform.Rotate(Vector3.up * 2);
    }

    public void RotateRight() //Controls for movement of the players rotation using E
    {
        transform.Rotate(-Vector3.up * 2);
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
        if (collision.gameObject.tag == "EnemyBullet")
        {
            takeDamaage();
        }
    }

    private IEnumerator DestroyBullet(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
        shooting = true;
    }
}
