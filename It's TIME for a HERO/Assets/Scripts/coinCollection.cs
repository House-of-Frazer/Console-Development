using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollection : MonoBehaviour
{

        public AudioSource moneySound;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //play coin noise
            moneySound.Play();
            //add 1 to money every time gain coin
            MoneySystem.theMoney += 1;  
            Destroy(gameObject);
        }
    }
}

