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
    
    public bool WaitToSpin = false; //true or false to wait to spin - 
    public bool spinning = false;
    

    public float speed; //used for the speed of movement - see Crash Movement
    public float spinCount; //ammount of seconds that the player spins - IEnumerator SpinAttackCount
    public float spinCoolDown; //ammount of seconds for the spin cool down - IEnumerator SpinCoolDown
    public float jumpForce = 8f;
    public float spinTimer;
    public float waitToSpinTimer;

    public int wumpas;
    public int lives;
    public int rotSpeed;

    public GameObject Crash; //crash prefab
    public GameObject SpinAttackPrefab; //spinattack model

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
       rigidbody = GetComponent<Rigidbody>();

        SpinAttackPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CrashMovement();
        SpinAttackPressed();
        Jumping();
        if (spinning == true)
        {
            Spinning();
        }
        if (WaitToSpin == true)
        {
            WaitToSpinTimer();
        }
    }

    /// <summary>
    /// Move as crash, move forward, backward, left, side
    /// </summary>
    private void CrashMovement()
    {
       
        //if "W" key preseed moves forward
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.MovePosition(transform.position += Vector3.forward * speed * Time.deltaTime); //moves forward on the z axis
        }
       
        //moves backwards when "S" is presse
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.MovePosition(transform.position += Vector3.back * speed * Time.deltaTime); //moves backwards on the z axis
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
        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
        {
            print("Player Jumped");

            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private bool OnGround()
    {
        bool onGround = false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            print("Touching Ground");
            onGround = true;

        }

        return onGround;
    }

    /// <summary>
    /// This makes the player go into an attack state
    /// </summary>
    private void SpinAttackPressed()
    {       
        if (Input.GetKeyDown(KeyCode.E) && WaitToSpin == false)
        {
            spinning = true;
            StartCoroutine(PlayerSpinTimer());
        }
    }

    public void Spinning()
    {
        Crash.SetActive(false);
        SpinAttackPrefab.SetActive(true); //intiate the spinattack prefab
        for (int i = 0; i < spinTimer; i++)
        {
            SpinAttackPrefab.transform.Rotate(0, rotSpeed, 0);
        }

    }

    IEnumerator PlayerSpinTimer()
    {
        yield return new WaitForSeconds(spinTimer);
        Crash.SetActive(true);
        SpinAttackPrefab.SetActive(false);
        spinning = false;
        WaitToSpin = true;
    }

    IEnumerator WaitToSpinTimer()
    {
        yield return new WaitForSeconds(waitToSpinTimer);
        WaitToSpin = false;
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
