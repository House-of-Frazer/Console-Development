using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyor : MonoBehaviour
{
    //scoll speed
    public float ScrollY = 0.5f;

    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        //get reference to renderer
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //set offset on the Y co-ordinate to Speed
        float OffsetY = Time.time * ScrollY;
        rend.materials[1].SetTextureOffset("_MainTex", new Vector2(0, OffsetY));
    }
}
