using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class changeLevel : MonoBehaviour
{
    public string LevelName;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            changeToLevel(LevelName);
        }
    }

    public static void changeToLevel(string lvl) {
        SceneManager.LoadScene(lvl);

    }
}
