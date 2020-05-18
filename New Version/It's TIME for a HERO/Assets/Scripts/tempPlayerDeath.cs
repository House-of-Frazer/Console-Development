using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tempPlayerDeath : MonoBehaviour
{
    //starting pos
    //private Vector3 playerStartPos;
    Scene currentScene;
    private GameObject player;
    private string _currentSceneName;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        //playerStartPos = player.transform.position;

        currentScene = SceneManager.GetActiveScene();
        _currentSceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < 0)
        {
            portal.levelChange(_currentSceneName);
        }
    }
}
