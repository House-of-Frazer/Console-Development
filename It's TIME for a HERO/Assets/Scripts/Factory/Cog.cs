using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog : MonoBehaviour
{
    public bool active;
    public bool reverse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeTravel.timeTravel == false)
        {
            if (active == true)
            {
                if (reverse == false)
                    transform.Rotate(0, 0, 1);
                if (reverse == true)
                    transform.Rotate(0, 0, -1);
            }
        }
    }
}
