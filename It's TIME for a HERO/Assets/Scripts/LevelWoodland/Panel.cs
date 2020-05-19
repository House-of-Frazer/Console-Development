using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject panel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) { 
            if (panel != null)
            {
                bool isActive = panel.activeSelf;
                panel.SetActive(!isActive);
            }
        }
    }
    public void openPanel()
    {
        
    }
}
