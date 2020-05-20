using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMusic : MonoBehaviour
{

    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
