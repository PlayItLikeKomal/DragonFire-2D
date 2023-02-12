using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class uimanager : MonoBehaviour
{
    public GameObject gameovermenu;
    private void OnEnable()
    {
        health.onplayerdeath += enablegameovermenu;
    }
    private void OnDisable()
    {
        health.onplayerdeath -= enablegameovermenu;
    }
    public void  enablegameovermenu()
    {
      //  gameovermenu.SetActive(true);
    }
    
    //public void gotomainmenu()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    //}
}
