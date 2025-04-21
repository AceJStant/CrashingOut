using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Ace J. Stant
 * Last updated 4/14/25
 * Making the code - timer and ability - of the breakable platforms
 */
public class BreakablePlatforms : MonoBehaviour
{
    public float PlatformTimer; //x amount of seconds that allows the plauyer to be on top til it turns invisible
    private int PlatformReturn = 5; //after five seconds the platform returns

    public bool PlatformOn = true; //determines if the platform is on or not

    public GameObject BreakablePlatform;
    
    void Update()
    {
        if (PlatformOn == false) //if platform is off the object is set off
        {
            BreakablePlatform.SetActive(false);
        } else //must be on 
        {
            BreakablePlatform.SetActive(true);
        }
        TurnOff();
    }

    /// <summary>
    /// Begins the turn off process of the platforms ability
    /// </summary>
    private void TurnOff()
    {
        RaycastHit hit;
        //If the raycast returns true then an object has been hit
        //when the player is hit from the top - crushed - the player respawns
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, maxDistance: 5f))
        {
            //if player hit the collider and ites tagged thwomp then respawn
            if (hit.collider.gameObject.tag == "Player")
            {
                StartCoroutine(TurnOffTimer());
            }
        }
    }

    /// <summary>
    /// Timer for that begins until the platform turns off for x amount
    /// </summary>
    /// <returns></returns>
    IEnumerator TurnOffTimer()
    {
        yield return new WaitForSeconds(PlatformTimer);
        StartCoroutine(PlatformReturnTimer());
        PlatformOn = false;

    }

    /// <summary>
    /// timer that begins for how long the platform is off until it returns on
    /// </summary>
    /// <returns></returns>
    IEnumerator PlatformReturnTimer()
    {
        yield return new WaitForSeconds(PlatformReturn);
        PlatformOn = true;
    }
}
