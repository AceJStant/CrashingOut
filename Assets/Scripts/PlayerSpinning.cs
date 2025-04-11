using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpinning : MonoBehaviour
{
    public GameObject PlayerMovement;
    public float SpinTimer;

    public int rotSpeed;
    public bool active;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       //if opacity of playermovement turns to 0
        {
            Spinning();
        }
    }

    /// <summary>
    /// Basically when it gets summoned
    /// </summary>
    public void Spinning()
    {
       
        gameObject.SetActive(true);
        transform.Rotate(rotSpeed, 0, 0);
        PlayerSpinTimer();
        
    }

    IEnumerator PlayerSpinTimer()
    {

        yield return new WaitForSeconds(SpinTimer);
        Destroy(gameObject);
    }


}
