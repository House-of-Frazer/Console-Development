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
        if (CameraSwitch.mainCamActive == false) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //Creates an object from where you clicked mutilpies the x coordinates by 12, and divides the z coordinates by 2-700, to fit them on larger map
                    GameObject obj = Instantiate(prefab, new Vector3(hit.point.x, hit.point.y - 1066, hit.point.z), Quaternion.identity) as GameObject;
                    obj.transform.localScale = new Vector3(40, 40, 40);
                }

            }
        }
    }
    
}
