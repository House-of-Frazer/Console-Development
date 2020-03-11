using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeMenuUI : MonoBehaviour
{
    public bool IsHidden; //Bool to see if menu is hidden or not
    public Button Back; //Back button
    public Button SaveGame; //Save Game button
    public Button LoadGame; //Load Game button
    public Button Options; //Options button
    public Button MainMenu; //Main Menu button
    public GameObject Background; //Background for menu



    public void HideMenu()
    {
            Background.SetActive(false);
            Back.enabled = false;
            Back.gameObject.SetActive(false);
            SaveGame.enabled = false;
            SaveGame.gameObject.SetActive(false);
            LoadGame.enabled = false;
            LoadGame.gameObject.SetActive(false);
            Options.enabled = false;
            Options.gameObject.SetActive(false);
            MainMenu.enabled = false;
            MainMenu.gameObject.SetActive(false);
    }

    public void ShowMenu()
    {
            Background.SetActive(true);
            Back.enabled = true;
            Back.gameObject.SetActive(true);
            SaveGame.enabled = true;
            SaveGame.gameObject.SetActive(true);
            LoadGame.enabled = true;
            LoadGame.gameObject.SetActive(true);
            Options.enabled = true;
            Options.gameObject.SetActive(true);
            MainMenu.enabled = true;
            MainMenu.gameObject.SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        IsHidden = true;
        HideMenu();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
