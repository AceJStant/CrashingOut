using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform portalExit;

    private void OnTriggerEnter(Collider other)
    {
        //Teleport any overlapped object by setting its position to the portal exit position
        other.transform.position = portalExit.position;

    }
}
