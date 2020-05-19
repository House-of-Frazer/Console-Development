using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCards : MonoBehaviour
{

    //when player collised with key card, check for tag and turn on approopaite bool in Door Script
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "redCard")
            {
                Doors.redKeyCard = true;
                Destroy(gameObject);
            }
            if (gameObject.tag == "blueCard")
            {
                Doors.blueKeyCard = true;
                Destroy(gameObject);
            }
        }
    }
}
