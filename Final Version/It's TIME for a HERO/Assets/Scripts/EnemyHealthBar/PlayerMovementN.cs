using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementN : MonoBehaviour
{
    public Rigidbody RB;
    public bool PlayerGrounded;
    public float movement = 0.1f;

    private Vector3 moveDirection;

    float axisHorizontal, axisVertical;


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>(); //Setup reference for the PlayerMovement script;
    }

    // Update is called once per frame
    void Update()
    {
        /*//requires the player to press space to jump
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

        */

        //moveDirection = (transform.forward * Input.GetAxis("MoveVertical") + transform.right * Input.GetAxis("MoveHorizontal"));
        //**moveDirection = (transform.right * Input.GetAxis("MoveHorizontal"));

        //transform.position = transform.position + moveDirection * Time.deltaTime * 5;

        //**heading += Input.GetAxis("MoveHorizontal") * Time.deltaTime;
        //**pivot.rotation = Quaternion.Euler(0, heading, 0);

        //**moveDirection = (transform.forward * Input.GetAxis("MoveHorizontal") * movement);
    
    }

    public void Forward() //Controls for movement using W when the player presses and holds the key
    {
        transform.Translate(Vector3.forward * movement, Camera.main.transform);
    }

    public void Left() //Controls for movement using A when the player presses and holds the key
    {
        transform.Translate(Vector3.left * movement, Camera.main.transform);
    }
    public void Right() //Controls for movement using S when the player presses and holds the key
    {
        transform.Translate(Vector3.right * movement, Camera.main.transform);
    }
    public void Backward() //Controls for movement using D when the player presses and holds the key
    {
        transform.Translate(-Vector3.forward * movement, Camera.main.transform);
    }

    public void RotateLeft()  //Controls for movement of the players rotation using Q
    {
        transform.Rotate(Vector3.up * 2);
    }

    public void RotateRight() //Controls for movement of the players rotation using E
    {
        transform.Rotate(-Vector3.up * 2);
    }


    public IEnumerator Jumping()
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
