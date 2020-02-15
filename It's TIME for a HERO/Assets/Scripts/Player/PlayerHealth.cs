using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int Health; //The player's Hp.
    public int NumberOfHearts; //The current number of player hearts.

    public Image[] Hearts; //An array of images to hold the max player hearts.
    public Sprite FullHeart; //The sprite for an full heart.
    public Sprite EmptyHeart; //The sprite for an empty heart.

    void Start() // Start is called before the first frame update
    {
        
    }

    void Update() // Update is called once per frame
    {
        for (int i = 0; i < Hearts.Length; i++) //Check if i is smaller then current amount of player hearts.
        {
            if (i < Health) //If i is less then health.
            {
                Hearts[i].sprite = FullHeart; //Makes the sprite an full heart.
            }
            else
            {
                Hearts[i].sprite = EmptyHeart; //Makes the sprite an empty heart.
            }

            if (i < NumberOfHearts) //If i is less then number of hearts.
            {
                Hearts[i].enabled = true; //If true make the hearts visable.
            }
            else
            {
                Hearts[i].enabled = false; //If true make the hearts visable.
            }
        }
    }
}
