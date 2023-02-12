using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float jumppower;

    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField]private float horizontal;
   [SerializeField] private float walljumpcooldown;
  

    public static object currenthealth { get; internal set; }

    void Update()
    {



        horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        if (horizontal > 0.01f)


            transform.localScale = Vector3.one;

        else if (horizontal < -0.01f)

            transform.localScale = new Vector3(-1, 1, 1);

        //bye adding grounded at end we can jump only if we r on the ground



        GetComponent<Animator>().SetBool("run", horizontal != 0);
        //telling animator that player is grounded or not
        GetComponent<Animator>().SetBool("grounded", IsGrounded());
        //GetComponent<Animator>().SetTrigger("jump");


        if (walljumpcooldown < 0.2f)
        {  
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal * _speed, GetComponent<Rigidbody2D>().velocity.y);
        if (onwall() && !IsGrounded())
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        }
        else

            GetComponent<Rigidbody2D>().gravityScale = 7;
        
            if (CrossPlatformInputManager.GetButtonDown("jump"))
            {
                jump();
            }
        }
        else
        
        {    walljumpcooldown += Time.deltaTime;



        }
  }


    private void jump()
    {

         if(IsGrounded())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumppower);
            //once player jumps it cannot be grounded anymore
            //  IsGrounded() = false;

        }
         else if (onwall() && !IsGrounded())
        {

            if(horizontal==0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            walljumpcooldown = 0;
            
        }


    }

   
    public bool IsGrounded()
    {
       
        RaycastHit2D raycastHit = Physics2D.BoxCast(GetComponent<BoxCollider2D>().bounds.center, GetComponent<BoxCollider2D>().bounds.size, 0, Vector2.down, 0.1f, groundlayer);
        return raycastHit.collider != null;
    }

    public bool onwall()
    {

        RaycastHit2D raycastHit = Physics2D.BoxCast(GetComponent<BoxCollider2D>().bounds.center, GetComponent<BoxCollider2D>().bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer) ;
        return raycastHit.collider != null;
    }

    public bool canattack()
    {
        return horizontal == 0 && IsGrounded() && !onwall();
    }
   



}


