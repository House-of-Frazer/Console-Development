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
    public GameObject prefab2;
    public GameObject mark;
    public float movement = 0.8f;
    public GameObject futureThing;

    // Use this for initialization
    void Start()
    {
        GraphicRaycaster gr = this.GetComponent<GraphicRaycaster>();
    }
    // Update is called once per frame
    void Update()
    {
        
        //var Mousepos = Input.mousePosition;
        // var lightPos = Camera.main.ScreenToWorldPoint(new Vector3(Mousepos.x, Mousepos.y, Mousepos.z));
        // mark.transform.position = lightPos;
        if (Input.GetAxis("Horizontal") > 0.0f) {
            mark.transform.Translate(Vector3.right * movement, Camera.main.transform);
        }
        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            mark.transform.Translate(Vector3.left * movement, Camera.main.transform);
        }
        if (Input.GetAxis("Vertical") > 0.0f)
        {
            mark.transform.Translate(Vector3.up * movement, Camera.main.transform);
        }
        if (Input.GetAxis("Vertical") < 0.0f)
        {
            mark.transform.Translate(Vector3.down * movement, Camera.main.transform);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            
            GameObject obj = Instantiate(prefab, new Vector3(mark.transform.position.x,mark.transform.position.y - 1096, mark.transform.position.z), Quaternion.identity) as GameObject;
            GameObject obj2 = Instantiate(prefab2, new Vector3(mark.transform.position.x, mark.transform.position.y + 1, mark.transform.position.z), Quaternion.identity) as GameObject;
            obj.transform.localScale = new Vector3(40, 40, 40);
            obj.transform.parent = futureThing.transform;

        }

        //ray
        if (CameraSwitch.mainCamActive == false) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //Creates an object from where you clicked mutilpies the x coordinates by 12, and divides the z coordinates by 2-700, to fit them on larger map
                    GameObject obj = Instantiate(prefab, new Vector3(hit.point.x, hit.point.y - 1066, hit.point.z), Quaternion.identity) as GameObject;
                    GameObject obj2 = Instantiate(prefab2, new Vector3(hit.point.x, hit.point.y + 1, hit.point.z), Quaternion.identity) as GameObject;
                    obj.transform.localScale = new Vector3(40, 40, 40);
                    obj.transform.parent = futureThing.transform;
                }

            }
        }
    }
    
}
