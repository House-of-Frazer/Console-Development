using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour

{

    public TextMesh text1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        text1.text = "Press 'T' to Talk";
    }

    public static implicit operator Text(bool v)
    {
        throw new NotImplementedException();
    }
}
