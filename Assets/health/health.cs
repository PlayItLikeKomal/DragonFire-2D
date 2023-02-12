using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    [SerializeField] private float startinghealth;
    private bool dead;
    public float currenthealth { get; private set; }
    public static event Action onplayerdeath;

    // Start is called before the first frame update

    private void Awake()
    {
        currenthealth = startinghealth;
    }
    public void addhealth(float _value)
    {
        currenthealth = Mathf.Clamp(currenthealth + _value, 0, startinghealth);
    }
    public void takedamage(float _damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - _damage, 0, startinghealth);
        if (currenthealth > 0)
        {
            GetComponent<Animator>().SetTrigger("hurt");
            

        }
        else


        {
            if (!dead)
            {
                GetComponent<Animator>().SetTrigger("die");
                //player
                if (GetComponent<player>() != null)
                    GetComponent<player>().enabled = false;
                //enemy
                //if (GetComponentInParent<enemypatrol>() != null)
                //      GetComponentInParent<enemypatrol>().enabled = false;


                //  if (GetComponent<enemy>() != null)
                //      GetComponent<enemy>().enabled = false;
                dead = true;

            }
            onplayerdeath?.Invoke();
            print("hi");
            SceneManager.LoadScene("try again"); }

    }

    public void _takedemage(float _damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - _damage, 0, startinghealth);
        if (currenthealth > 0)
        {
            GetComponent<Animator>().SetTrigger("hurt");

        }
        else



          if (!dead)
        {
            GetComponent<Animator>().SetTrigger("die");
            //player

            //enemy
            if (GetComponentInParent<enemypatrol>() != null)
                GetComponentInParent<enemypatrol>().enabled = false;


            if (GetComponent<enemy>() != null)
                GetComponent<enemy>().enabled = false;
            dead = true;

        }
    }

    private void diactivate()
    {
      gameObject.SetActive(false);
    }
  }

    

   

    
