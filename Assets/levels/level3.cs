using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level3: MonoBehaviour
{


    public void restart()
    {
        SceneManager.LoadScene("level3. 3");
        /*

    Scene scene = SceneManager.GetActiveScene();
       SceneManager.LoadScene(scene.name);      if (GUI.Button(scene.name))
     {
          SceneManager.LoadScene(scene.name);
     }*/
    }

}