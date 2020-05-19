using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedAttack : MonoBehaviour
{
    public GameObject player; //Object to reference the Player

    private float movementSpeed = 6f; //Movement speed of the cube

    private float lifeTime = 10f; //How long the bullet survives beore being destroyed

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Find the player and set it to player
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 variable on the direction of which to face
        Vector3 runToDirection;

        //Move the bullet forward
        gameObject.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        //Set the direction based on the player's position and the AI's current position
        runToDirection = player.transform.position - gameObject.transform.position;

        lifeTime -= 1f * Time.deltaTime;

        if (lifeTime < 0)
            Destroy(gameObject);
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
    }
}
