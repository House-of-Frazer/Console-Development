using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public bool questAccepted = false;
    public bool ballCollected = false;
    public bool questCompelted = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Quest")
            {
                if (ballCollected == false)
                {
                 questAccepted = true;
                }
                if(ballCollected == true)
             {
                 questCompelted = true;
                //Give score
             }
        }
        if(collision.gameObject.tag == "Ball")
        {
            ballCollected = true;
            Destroy(collision.gameObject);
            ballCollected = true;
        }
    }
    
}
