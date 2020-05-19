using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A script to reset the player if they fall out of the level
 * The script resets the player to the 'world spawn position'
 * This activates if the player's Y position is less than 0
 * All levels terrain 'should' be above Y:0 anyway.
 * This is a test script, but could be fleshed out to be in the final build
 *      camera fade?
 *      reset world / checkpoint
 */
public class resetPlayer : MonoBehaviour
{
    //starting pos
    private Vector3 playerStartPos;
    private GameObject player;
       
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        playerStartPos = player.transform.position;         
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < 0) {
            setplayertoBeginning();
        }
    }

    public void setplayertoBeginning() {
        player.transform.position = playerStartPos ;
    }
}
