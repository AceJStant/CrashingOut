using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Name:Jose Bucio
 * Last Updated:4/14/25
 * Description:Controls menus
 */
public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void QuitGame()
    {

        Application.Quit();



    }

    public void SwitchScene(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex);


    }


}


