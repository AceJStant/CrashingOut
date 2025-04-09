using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;
    private Vector3 leftPos;
    private Vector3 rightPos;
    public int speed;
    public bool goingLeft;

    // Start is called before the first frame update
    void Start()
    {
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    /// <summary>
    /// The Enemy movement code
    /// </summary>
    private void EnemyMove()
    {
        if (goingLeft)
        {
            if (transform.position.x <= leftPos.x)
            {
                goingLeft = false;
            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
        else
        {
            if (transform.position.x >= rightPos.x)
            {
                goingLeft = true;
            }
            else
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
    }

    /// <summary>
    /// Enemy Damages player script
    /// </summary>
    /// <param name="collision"></param>
    //Check for physical collisions with the player
    private void OnCollisionEnter(Collision collision)
    {
        //Check if the colliding object has the player script
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            //Have the Player lose a Life
            collision.gameObject.GetComponent<PlayerMovement>().LoseLife();
        }
    }

    //Check for overlap with the Player
    private void OnTriggerEnter(Collider other)
    {
        //Check if the colliding object has the player script
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            //Have the Player lose a Life
            other.gameObject.GetComponent<PlayerMovement>().LoseLife();
        }
    }
}

