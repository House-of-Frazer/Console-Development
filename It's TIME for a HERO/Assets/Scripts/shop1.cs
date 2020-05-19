using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityStandardAssets.Character.Player;

public class shop1 : MonoBehaviour
{
    public GameObject shopInventory;
    public GameObject Item1Text;
    public GameObject Item2Text;
    public GameObject Item3Text;
    public GameObject Item4Text;
    public GameObject itemCompletion;
    public GameObject completeText;
   

    public GameObject shopPanel;
    public KeyCode TKey;

    //public GameObject thePlayer;
   

    void Start()
    {
        //shopInventory.SetActive(false);
        itemCompletion.SetActive(false);
        // completeText.SetActive(false);

    }

    void OnTriggerEnter()
    {
            shopInventory.SetActive(true);
            shopStuff.shopNumber = 1;

            Item1Text.GetComponent<Text>().text = "" + shopStuff.Item1;
            Item2Text.GetComponent<Text>().text = "" + shopStuff.Item2;
            Item3Text.GetComponent<Text>().text = "" + shopStuff.Item3;
            Item4Text.GetComponent<Text>().text = "" + shopStuff.Item4;
    }

    public void Item1()
    {
        itemCompletion.SetActive(true);
        completeText.GetComponent<Text>().text = "Are you sure you wish to buy " + shopStuff.Item1 + "?";
    }
    public void Item2()
    {
        itemCompletion.SetActive(true);
        completeText.GetComponent<Text>().text = "Are you sure you wish to buy " + shopStuff.Item2 + "?";
    }
    public void Item3()
    {
        itemCompletion.SetActive(true);
        completeText.GetComponent<Text>().text = "Are you sure you wish to buy " + shopStuff.Item3 + "?";
    }
    public void Item4()
    {
        itemCompletion.SetActive(true);
        completeText.GetComponent<Text>().text = "Are you sure you wish to buy " + shopStuff.Item4 + "?";
    }

    public void cancelTransaction()
    {
        itemCompletion.SetActive(false);
    }
}
