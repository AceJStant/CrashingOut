using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Ace J. Stant
 * Last updated 4/21/25
 * script for making the checkpoint the players new respawn point
 */
public class CheckPoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().respawnPoint = gameObject.transform.position;

        }
    }
}
