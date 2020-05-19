using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 cameraOffset;

    [Range (0.01f, 1.0f)]
    public float Smoothness = 0.5f;

    public bool LookAtPlayer = false;
    bool RotatePlayer= true;
    public float RotationSpeed = 5.0f;



    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (TimeTravel.timeTravel == false)
        {
            if (RotatePlayer)
            {
                Quaternion camTurnAngle =
                        Quaternion.AngleAxis(Input.GetAxis("Horizontal") * RotationSpeed, Vector3.up);

                cameraOffset = camTurnAngle * cameraOffset;
            }

            Vector3 newPos = PlayerTransform.position + cameraOffset;

            transform.position = Vector3.Slerp(transform.position, newPos, Smoothness);


            if (LookAtPlayer || RotatePlayer)
            {
                transform.LookAt(PlayerTransform);
            }
        }
    }
}
