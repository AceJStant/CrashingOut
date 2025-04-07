using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpinning : MonoBehaviour
{
    public float rotSpeed = 0.5f;
    public float SpinTimer;

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
}
