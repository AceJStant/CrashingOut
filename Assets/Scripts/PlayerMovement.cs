using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/* Ace J. Stant
 * 4/7/25
 * Player Movement 
 */
public class PlayerMovement : MonoBehaviour
{
    private bool spinning = false; //true or false in spin state - See Spin Attack
    private bool WaitToSpin = false; //true or false to wait to spin - 

    public float speed; //used for the speed of movement - see Crash Movement
    public float spinCount; //ammount of seconds that the player spins - IEnumerator SpinAttackCount
    public float spinCoolDown; //ammount of seconds for the spin cool down - IEnumerator SpinCoolDown
   

    public GameObject PlayerSpinning;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CrashMovement();
        SpinAttack();
        
    }

    /// <summary>
    /// Move as crash, move forward, backward, left, side
    /// </summary>
    private void CrashMovement()
    {
       
        //if "W" key preseed moves forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime; //moves forward on the z axis
        }
       
        //moves backwards when "S" is presse
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime; //moves backwards on the z axis
        }

        //Press A and you move left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime; //moves backwards on the z axis
        }

        //Press D and you move left
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime; //moves backwards on the z axis
        }
    }
    /// <summary>
    /// This makes the player go into an attack state
    /// </summary>
    private void SpinAttack()
    {
        if (WaitToSpin == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("spinattack");
                SpinAttackCount();

            }
        }
    }


    IEnumerator SpinAttackCount()
    {

        //start the timer
                yield return new WaitForSeconds(spinCount);
        //stop spinning after timer is done
        //gameObject.SetActive(true);

    }

    IEnumerator SpinCoolDown()
    {
        //start cool down 
        yield return new WaitForSeconds(spinCoolDown);
        //stop cooldown 
        WaitToSpin = false;
    }
}
