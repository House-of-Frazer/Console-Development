using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public int Health; //The player's Hp.
    public int CurrentNumberofHearts; //Current number of hearts the player has.
    int PreviousNumberofHearts; //Previous number of max hearts.
    int HeartCount = 0; //Current Heart Count for drawing hearts to screen.

    public Image FullHeart; //The heart texture;

    public Transform Parent; //The parent for the new heart objects.

    private ArrayList Hearts = new ArrayList(); //An arraylist to store all of the hearts.

    public void AddHearts(int AmountofHearts) //Add a heart to the player.
    {
        for (int i = 0; i < AmountofHearts; i++) //While i is less than amount of hearts.
        {

            Transform NewHeart = Instantiate(FullHeart.gameObject).transform; //Add heart to screen.
            NewHeart.SetParent(Parent, false); //Set parent of newly spawned object.

            if (i >= 5)
            {
                NewHeart.position += new Vector3(0 + (HeartCount * 40), -50, 0); //Sets position of hearts.
                HeartCount++; //Adds to the heart count.
            }
            else
            {
                NewHeart.position += new Vector3(0 + (i * 40), 0, 0); //Sets position of hearts.
            }

            Hearts.Add(NewHeart); //Add the new heart to the array.
        }
    }

    public void ClearScreen() //Clears the hearts off of screen.
    {
        Hearts.Clear(); //Clears the hearts array.
        HeartCount = 0; //Heart count becomes 0.
        foreach (Transform child in Parent.transform) //For each child of parent.
        {
            GameObject.Destroy(child.gameObject); //Destroy child object.

        }
    }

    void Start() // Start is called before the first frame update
    {
        CurrentNumberofHearts = 3; //Sets number of hearts to 3.
        Health = CurrentNumberofHearts; //Sets health to be the same as max hearts.
        AddHearts(CurrentNumberofHearts); //Current max hearts is equal to hearts on screen.
        PreviousNumberofHearts = CurrentNumberofHearts; //Previous max hearts is equal to current max hearts.
    }

    void Update()
    {
        CurrentNumberofHearts = Mathf.Clamp(CurrentNumberofHearts, 0, 10); //Makes 10 the maximum amount of hearts.
        if (CurrentNumberofHearts != PreviousNumberofHearts) //If current max amount of hearts is not equal to previous max hearts.
        {
            ClearScreen(); //Run clear screen function.
            PreviousNumberofHearts = CurrentNumberofHearts; //Previous max hearts is equal to current max hearts.
            AddHearts(CurrentNumberofHearts); //Current max hearts is equal to hearts on screen.
        }
    }
}
