using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2 : MonoBehaviour
{


    public void restart()
    {
        SceneManager.LoadScene("level3. 1");
        /*

    Scene scene = SceneManager.GetActiveScene();
       SceneManager.LoadScene(scene.name);      if (GUI.Button(scene.name))
     {
          SceneManager.LoadScene(scene.name);
     }*/
    }

}