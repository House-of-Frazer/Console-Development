using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip HubMusic;
    public AudioClip IcePast;
    public AudioClip IceFuture;
    public AudioClip FactoryPast;
    public AudioClip FactoryFuture;
    public AudioClip Village;

    AudioSource audioSource;

    string CurrentScene;

    TimeTravel timeTravel;

    public bool MyFunctionCalled = false;

    void Awake()
    {
        timeTravel = GetComponent<TimeTravel>();
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        CurrentScene = SceneManager.GetActiveScene().name;     
    }

    void Music()
    {
        if (CurrentScene == "Hub")
        {
            audioSource.clip = HubMusic;
            audioSource.Play();
        }

        if (CurrentScene == "Factory")
        {
            if (timeTravel.inPast == false)
            {
                audioSource.clip = FactoryFuture;
                audioSource.Play();
                return;
            }
            if (timeTravel.inPast == true)
            {
                audioSource.clip = FactoryPast;
                audioSource.Play();
                return;
            }
        }

        if (CurrentScene == "IceMountain")
        {
            if (timeTravel.inPast == false)
            {
                audioSource.clip = IceFuture;
                audioSource.Play();
            }
            if (timeTravel.inPast == true)
            {
                audioSource.clip = IcePast;
                audioSource.Play();
            }
        }

        if (CurrentScene == "Village")
        {
            audioSource.clip = Village;
            audioSource.Play();
        }
    }

    void Update()
    {
        if(MyFunctionCalled == false)
        {
            MyFunctionCalled = true;
            Music();
        }
    }

}
