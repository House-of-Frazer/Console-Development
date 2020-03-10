using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MakeMarker : MonoBehaviour
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
                //Creates as marker of where the buildngs are, works the same as "MakeOBJ" but doesnt change the X or Z coordinates to fit on larger map
                GameObject obj = Instantiate(prefab, new Vector3(hit.point.x , hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
                
            }

        }
    }
}
