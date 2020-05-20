using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{

    public GameObject moneyText;
    public static int theMoney;
   

    void Update()
    {
        //if (gameObject.tag == "Player")
       //{
            //add int value to string, on UI
            moneyText.GetComponent<Text>().text = "MONEY: " + theMoney;
       //}
    }




}
