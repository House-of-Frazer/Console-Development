using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeConker : MonoBehaviour
{
    public HealthUI healthUi;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Player"))
        {
            healthUi.CurrentNumberofHearts -= 1;
            healthUi.ClearScreen();
        }

    }
}
