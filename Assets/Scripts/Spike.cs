using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Check if colliding object was the player
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            //Have player lose a life 
            collision.gameObject.GetComponent<PlayerMovement>().


        }

    }

    //Cjecks for overlap with the player
    private void OnTriggerEnter(Collider other)
    {
        //Check if colliding object was the player
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            //Have player lose a life 
            other.gameObject.GetComponent<PlayerMovement>().


        }




    }
}
