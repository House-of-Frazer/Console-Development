using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public static bool redKeyCard = false; //static bool to see if player has collected red key card
    public static bool blueKeyCard = false; //static bool to see if player has collected blue key card

    // Start is called before the first frame update
    void Start()
    {
        /*if (redKeyCard == true)
        {
            gameObject.SetActive(false);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        //check tag of object and remove doors with that tag when associated bool is true
        if (gameObject.tag == "redDoor")
        {
            if (redKeyCard == true)
            {
                gameObject.SetActive(false);
            }
        }
        if (gameObject.tag == "blueDoor")
        {
            if (blueKeyCard == true)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
