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
    
    private bool WaitToSpin = false; //true or false to wait to spin - 

    public float speed; //used for the speed of movement - see Crash Movement
    public float spinCount; //ammount of seconds that the player spins - IEnumerator SpinAttackCount
    public float spinCoolDown; //ammount of seconds for the spin cool down - IEnumerator SpinCoolDown
    public float jumpForce = 8f;

    public int wumpas;
    public int lives;

    public GameObject PlayerSpinning;

    private Rigidbody Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
       Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CrashMovement();
        SpinAttack();
        Jumping();
    }

    /// <summary>
    /// Move as crash, move forward, backward, left, side
    /// </summary>
    private void CrashMovement()
    {
       
        //if "W" key preseed moves forward
        if (Input.GetKey(KeyCode.W))
        {
            Rigidbody.MovePosition(transform.position += Vector3.forward * speed * Time.deltaTime); //moves forward on the z axis
        }
       
        //moves backwards when "S" is presse
        if (Input.GetKey(KeyCode.S))
        {
            Rigidbody.MovePosition(transform.position += Vector3.back * speed * Time.deltaTime); //moves backwards on the z axis
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
            //transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

    public void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// This makes the player go into an attack state
    /// </summary>
    private void SpinAttack()
    {       
        if (Input.GetKeyDown(KeyCode.E) && WaitToSpin == false)
        {
            print("spinattack");
        }
        
    }

    public void LoseLife()
    {
        lives--;

        if(lives == 0)
        {
            //change to gameover
        } else //must have lives
        {
            //respawn - possible respawn points must be made
        }
    }
    
    /// <summary>
    /// when wumpas == 100, player gains a life
    /// </summary>
    public void GainLife()
    {
        if (wumpas == 100) //equals to 100
        {
            lives++; //1 life gained
        }
    }
    
}
