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
}
