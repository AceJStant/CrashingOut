using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpinning : MonoBehaviour
{
    public float rotSpeed = 0.5f;
    public float SpinTimer;

    public int wumpas;
    public int lives;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotSpeed, 0);
    }

    /// <summary>
    /// Basically when it gets summoned
    /// </summary>
    public void Spinning()
    {
        //start timer
        PlayerSpinTimer();
    }

    IEnumerator PlayerSpinTimer()
    {
        yield return new WaitForSeconds(SpinTimer);
        Destroy(gameObject);
    }

    public void LoseLife()
    {
        lives--;

        if (lives == 0)
        {
            //add change in scenes
        } else
        {
            //add code to make respawn
        }
    }

}
