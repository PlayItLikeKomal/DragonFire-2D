using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float attackcooldown;
    public float colliderdistance;
    public float range;
    public int damage;
    private float cooldowntimer=Mathf.Infinity;
    public BoxCollider2D boxCollider;
    public LayerMask playerlayer;
    private health playerHealth;
    private enemypatrol enemypatrol;
    private health enemyhealth;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        enemypatrol = GetComponentInParent<enemypatrol>();
    }
    void Update()
    {
        cooldowntimer += Time.deltaTime;
        if(cooldowntimer>=attackcooldown)
        {
            cooldowntimer = 0;
            GetComponent<Animator>().SetTrigger("mattack");
        }

        if (enemypatrol != null)
            enemypatrol.enabled = !playerInsight();

    }

    private bool playerInsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x*colliderdistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),0,
            Vector2.left, 0, playerlayer);
        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<health>();
        

        return hit.collider != null;

       

    }
    private void OnDrawGizmos()
    {                                                                         //player collider moves left right
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderdistance,
              new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    private void DamagePlayer()
    {
        if (playerInsight())
            enemyhealth._takedemage(damage);
    }
    
}
