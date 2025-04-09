using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wumpa : MonoBehaviour
{
    public float rotSpeed = 1;

    private void Update()
    {
        //Rotates coin each frame
        transform.Rotate(0, rotSpeed, 0);


    }


    private void OnTriggerEnter(Collider other)
    {
        //Check if touched object was the player
        if (other.GetComponent<PlayerMovement>())
        {
            //Increase player's coin count by 1
            other.GetComponent<PlayerMovement>().wumpas++;


            //Coin removes itself from the game
            Destroy(gameObject);


        }





    }
}
