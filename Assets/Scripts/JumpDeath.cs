using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDeath : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        CheckingForDanger ();
    }

    //RayCast for the enemies to die from jumping
    public void CheckingForDanger()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, maxDistance: 0.8f))
        {
            //If player is above the enemy will die
            if (hit.collider.gameObject.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
    }
}
