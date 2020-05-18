using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempShaderPingPong : MonoBehaviour
{
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float dissolveAmount = Mathf.PingPong(Time.time, 2.0f);
        rend.material.SetFloat("_Amount", dissolveAmount);
    }
}
