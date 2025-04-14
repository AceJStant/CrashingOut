using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/*
 * Name:Jose Bucio
 * Last Updated:4/5/25
 * Description:Controls UI
 */
public class UI_Manager : MonoBehaviour
{
    public TMP_Text wumpasText;
    public PlayerMovement playerMovement;
    public TMP_Text livesText;


    // Update is called once per frame
    void Update()
    {
        wumpasText.text = "Wumpas: " + playerMovement.wumpas;
        livesText.text = "Lives: " + playerMovement.lives;
    }
}
