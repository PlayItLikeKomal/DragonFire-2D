using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour

{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    private float currentpostx;
    private Vector3 velocity = Vector3.zero;


    private void Update()
    {  //room
       //  transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentpostx, transform.position.y, transform.position.z), ref velocity, speed);
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
        public void movetonewroom(Transform _newroom)
        {
            currentpostx = _newroom.position.x;
        }
    
}