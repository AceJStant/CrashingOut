using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Carter Prestwich
//4/12/2025
//Controls enemy variables like speed and types of enemies
//You can change enemy pathing in the game scene

//List the different enemy types, can be changed in the inspector 
public enum EnemyType
{
    //Only dies from spin attack
    SpikyTurtle,
    //Only dies from jumping on top
    Shielded,
    // Dies from both jump and spin attack
    RegularEnemy 
}

public class EnemyController : MonoBehaviour
{
    //Determines where the enemy will go to thier left
    public GameObject leftPoint;
    //Determines where the enemy will go to thier right
    public GameObject rightPoint;
    private Vector3 leftPos;
    private Vector3 rightPos;
    //Changes enemy speed in inspector
    public int speed;
    //Tells if enemy moves to the left
    public bool goingLeft;
    //Changes enemy type in inspector
    public EnemyType enemyType;

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
    /// The enemy movement code 
    /// </summary>
    private void EnemyMove()
    {
        //Check the direction the enemy is currently moving
        if (goingLeft)
        {
            //If the enmey has reached the left boundray
            if (transform.position.x <= leftPos.x)
            {
                //Now go right
                goingLeft = false;
            }
            //If not keep going
            else
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
        else
        {
            //If the enmey has reached the right boundray
            if (transform.position.x >= rightPos.x)
            {
                //Now go left
                goingLeft = true;
            }
            else
            {
                //If not keep going
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
    }

    /// <summary>
    /// See if collision is with the player, then play out effects for different enemy types
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            //Gets the playermovement that collided with the enemy to see if they are spinning or should loselife
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            //This will see the first part of contact betwee the player and enemies collision
            ContactPoint contact = collision.GetContact(0);
            //Checks if the players is above the enemy, can use boxcollider or a rigidbody to determine
            bool jumpedOn = contact.normal.y > 0.5f;

            // Check collision if player is spin attacking
            if (player.spinning)  
            {
                //SpikyTurtle dies from spin attack
                if (enemyType == EnemyType.SpikyTurtle)
                {
                    Die(); 
                }
                // RegularEnemy dies from spin attack
                else if (enemyType == EnemyType.RegularEnemy)
                {
                    Die(); 
                }
            }
            //Checks collision when player is not spinning
            else
            {
                // SpikyTurtle kills the player if not spinning
                if (enemyType == EnemyType.SpikyTurtle)
                {
                    player.LoseLife(); 
                }
                // Shielded dies if jumped on
                else if (enemyType == EnemyType.Shielded)
                {
                    if (jumpedOn)
                    {
                        Die();
                    }
                    // Shielded kills player if attacked
                    else
                    {
                        player.LoseLife(); 
                    }
                        
                }
                //Checks if player is either jumping or spin attacking regualr enemy
                else if (enemyType == EnemyType.RegularEnemy)
                {
                    //regular enemy dies
                    if (jumpedOn || player.spinning)
                    {
                        Die();
                    }
                    else
                    {
                        player.LoseLife();
                    }
                }
            }
        }
    }

    /// <summary>
    /// See if trigger is with the player, then play out effects for different enemy types
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            // Check if player is spin attacking
            if (player.spinning)
            {
                // SpikyTurtle dies from spin attack
                if (enemyType == EnemyType.SpikyTurtle)
                {
                    Die(); 
                }
                // RegularEnemy dies from attack
                else if (enemyType == EnemyType.RegularEnemy)
                {
                    Die(); 
                }
            }
            // Handle collision when player is not spinning
            else
            {
                // Shielded kills player if not jumping
                if (enemyType == EnemyType.Shielded)
                {
                    player.LoseLife(); 
                }
                // RegularEnemy dies from attack
                else if (enemyType == EnemyType.RegularEnemy)
                {
                    if (player.spinning)
                    {
                        Die();
                    }
                    else
                    {
                        player.LoseLife();
                    }
                }
            }
        }
    }

    //Enemy will despawn if correct attack is used
    private void Die()
    {
        Destroy(gameObject);
    }
}
