using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name:Jose Bucio
 * Last Updated:4/5/25
 * Description:Portal control
 */
public class Portal : MonoBehaviour
{
    public Transform portalExit;

    private void OnTriggerEnter(Collider other)
    {
        //Teleport any overlapped object by setting its position to the portal exit position
        other.transform.position = portalExit.position;

        if(other.gameObject.GetComponent<PlayerMovement>())
        {
            other.gameObject.GetComponent<PlayerMovement>().respawnPoint = portalExit.position;



        }
            
            
    }
}
