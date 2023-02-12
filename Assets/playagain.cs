using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playagain : MonoBehaviour
{


    public void restart()
    {
        SceneManager.LoadScene("levelmenu");
        /*

    Scene scene = SceneManager.GetActiveScene();
       SceneManager.LoadScene(scene.name);      if (GUI.Button(scene.name))
     {
          SceneManager.LoadScene(scene.name);
     }*/
    }

}