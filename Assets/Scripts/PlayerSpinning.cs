using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpinning : MonoBehaviour
{
    
    public float SpinTimer;

    public int rotSpeed;
   

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(rotSpeed,0, 0);
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
