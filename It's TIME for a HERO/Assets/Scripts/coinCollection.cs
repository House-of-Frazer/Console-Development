using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollection : MonoBehaviour
{

    public AudioClip moneySound;
    public float _timer = 0;
    bool _activated;

    AudioSource audioSource;
    Renderer rend;
    Collider collider;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = moneySound;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _activated = true;
            //play coin noise
            audioSource.Play();
            //add 1 to money every time gain coin
            MoneySystem.theMoney += 1;

        }
    }

    private void Update()
    {
        if (_activated == true)
        {
            Destroy(rend);
            Destroy(collider);

            _timer += Time.deltaTime;

            if (_timer > 1)
            {
                //Once the enemy has dissolved, destroy the gameobject
                Destroy(gameObject);
            }
        }
    }
}

