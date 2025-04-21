using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Name:Jose Bucio
 * Last Updated:4/5/25
 * Description:Crate Control
 */
public class Crate : MonoBehaviour
{
    public GameObject wumpaPrefab;
    public int spawnWumpaAmount = 3;

    // Update is called once per frame
    void Update()
    {
        CheckingForDanger();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>().spinning == true)
        {

            DestroyCrate();


        }




    }
    /// <summary>
    /// Destroys crate 
    /// </summary>
    public void DestroyCrate()
    {

        Destroy(gameObject);

        for (int i = 0; i < spawnWumpaAmount; i++)
        {
            GameObject wumpa = Instantiate(wumpaPrefab, transform.position, wumpaPrefab.transform.rotation);
        }
        
    }

    //Breaks crate if player is above
    public void CheckingForDanger()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, maxDistance: 0.8f))
        {
            //If player is above the crate will die
            if (hit.collider.gameObject.tag == "Player")
            {
                DestroyCrate();
            }
        }
    }
}
