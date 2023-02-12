using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class enemy_sideways : MonoBehaviour
{
   // public static event Action onplayerdeath;
    [SerializeField] private float damage;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<health>().takedamage(damage);

           // onplayerdeath?.Invoke();
        }
    }
}
