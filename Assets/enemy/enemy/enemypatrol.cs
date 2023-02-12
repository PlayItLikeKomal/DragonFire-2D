using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemypatrol : MonoBehaviour
{

    [SerializeField] private Transform leftedge;
    [SerializeField] private Transform rightedge;
    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;
    [SerializeField] private float idleDuration;
    private float idleTimer;
    [SerializeField] private Animator a;

    private void Awake()
     {
         initScale = enemy.localScale;
       // a = GetComponent<Animator>();
     } 
     private void OnDisable()
     {
        // GetComponent<Animator>().SetBool("moving", false);
      // a.SetBool("moving", false);
    } 
    
    private void Update()
    { 
        
        if (movingLeft)
         {
             if (enemy.position.x >= leftedge.position.x)
                 MoveInDirection(-1);
             else
                 DirectionChange();
         }
         else
         {
             if (enemy.position.x <= rightedge.position.x)
                 MoveInDirection(1);
             else
                 DirectionChange();
         }
     }

     private void DirectionChange()
     {
     // a.SetBool("moving", false);
      //  idleTimer += Time.deltaTime;
      //
      //   if (idleTimer > idleDuration)
             movingLeft = !movingLeft;
     }

     


        private void MoveInDirection(int _direction)
        {
          // idleTimer = 0;

       //  a.SetBool("moving", true);

            //Make enemy face direction
           enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
               initScale.y, initScale.z);

            //Move in that direction
            enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
                enemy.position.y, enemy.position.z);
        }



    } 
