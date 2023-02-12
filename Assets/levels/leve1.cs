using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leve1 : MonoBehaviour
{


    public void level1()
    {
        SceneManager.LoadScene("level3. 4");
        /*

    Scene scene = SceneManager.GetActiveScene();
       SceneManager.LoadScene(scene.name);      if (GUI.Button(scene.name))
     {
          SceneManager.LoadScene(scene.name);
     }*/
    }

}