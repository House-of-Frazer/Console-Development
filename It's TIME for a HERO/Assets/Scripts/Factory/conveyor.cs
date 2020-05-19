using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyor : MonoBehaviour
{
    //scoll speed
    public float ScrollY = -0.5f;

    //Transform to hold end point of conveyors
    public Transform endPoint;

    //object to hold renderer
    Renderer rend;

    //bool to change active status of conveyoer
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        //get reference to renderer
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeTravel.timeTravel == false)
        {
            if (active == true)
            {
                //set offset on the Y co-ordinate to Speed
                float OffsetY = Time.time * ScrollY;
                if (gameObject.layer == 8) //if it is conveyor
                    rend.materials[0].SetTextureOffset("_MainTex", new Vector2(0, OffsetY));
                if (gameObject.layer == 9) //if it is conveyor end
                    rend.materials[1].SetTextureOffset("_MainTex", new Vector2(0, OffsetY));
            }
        }

    }

    private void OnTriggerStay(Collider collision)
    {
        if (TimeTravel.timeTravel == false)
        {
            if (active == true)
            {
                if (collision.gameObject.tag == "Player")
                {
                    //move player along conveyor towards end poing
                    collision.transform.position = Vector3.MoveTowards(collision.transform.position, endPoint.position, -ScrollY / 12);
                }
            }
        }
    }
}
