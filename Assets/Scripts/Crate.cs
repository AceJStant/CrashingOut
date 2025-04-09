using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (other.GetComponent<PlayerSpinning>())
        {

            DestroyCrate();


        }




    }

    public void DestroyCrate()
    {

        Destroy(gameObject);

        for (int i = 0; i < spawnWumpaAmount; i++)
        {
            GameObject wumpa = Instantiate(wumpaPrefab, transform.position, wumpaPrefab.transform.rotation);
        }
        


    }
}
