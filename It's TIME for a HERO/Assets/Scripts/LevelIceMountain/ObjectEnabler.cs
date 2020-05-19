using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEnabler : MonoBehaviour
{
    bool _enabled;
    public GameObject obj1, obj2;

    // Start is called before the first frame update
    void Start()
    {
        _enabled = false;
        obj1.SetActive(false);
        obj2.SetActive(false);
               

    }

    // Update is called once per frame
    void Update()
    {
        if (_enabled)
        {
            obj1.SetActive(true);
            obj2.SetActive(true);
           
        }
     }

    void OnTriggerEnter(Collider coll) {
        if (coll.gameObject.tag == "Player") {
            _enabled = true;
        }
    }
}
