using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MakeOBJ : MonoBehaviour
{
    
    Ray ray;
    RaycastHit hit;
    public GameObject prefab;

    

    // Use this for initialization
    void Start()
    {
        GraphicRaycaster gr = this.GetComponent<GraphicRaycaster>();
    }
    // Update is called once per frame
    void Update()
    {
        //ray
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Creates an object from where you clicked mutilpies the x coordinates by 12, and divides the z coordinates by 2-700, to fit them on larger map
                GameObject obj = Instantiate(prefab, new Vector3(hit.point.x * 12, hit.point.y, hit.point.z/2-700), Quaternion.identity) as GameObject;
                obj.transform.localScale += new Vector3(2241, 1368, 2165);
            }

        }
    }
    
}
