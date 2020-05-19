using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitShop : MonoBehaviour
{
    public GameObject Panel;
    public KeyCode TKey;

    private void Update()
    {
        if (Input.GetKeyDown(TKey))
        {
            Panel.SetActive(false);
        }
    }
    

}
