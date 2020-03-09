using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementN : MonoBehaviour
{
    public Rigidbody RB;
    bool PlayerGrounded;
    public float movement;

    private Vector3 moveDirection;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //requires the player to press space to jump
        if (Input.GetKeyDown(KeyCode.Space) && PlayerGrounded)
        {
            StartCoroutine(Jumping());
        }

        //Controles for movement using WASD when the player presses and holds the key
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movement, Camera.main.transform);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movement, Camera.main.transform);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * movement, Camera.main.transform);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movement, Camera.main.transform);
        }

        //Controls for movement of the players rotation using Q and E keys to look around and behind themselves
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * 2);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(-Vector3.up * 2);
        }


        //moveDirection = (transform.forward * Input.GetAxis("MoveVertical") + transform.right * Input.GetAxis("MoveHorizontal"));
        //**moveDirection = (transform.right * Input.GetAxis("MoveHorizontal"));

        //transform.position = transform.position + moveDirection * Time.deltaTime * 5;

        //**heading += Input.GetAxis("MoveHorizontal") * Time.deltaTime;
        //**pivot.rotation = Quaternion.Euler(0, heading, 0);

        //**moveDirection = (transform.forward * Input.GetAxis("MoveHorizontal") * movement);

    }

    IEnumerator Jumping()
    {
        RB.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        PlayerGrounded = false;
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            PlayerGrounded = true;
        }
    }
}
