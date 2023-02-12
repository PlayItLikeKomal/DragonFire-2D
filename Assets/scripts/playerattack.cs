using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class playerattack : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    [SerializeField] private float cooldowntimer = Mathf.Infinity;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;
    private player player;
    

    // Update is called once per frame
    void Update()
    {
       
     
            if (CrossPlatformInputManager.GetButtonDown("fire") && cooldowntimer > attackcooldown && GetComponent<player>().canattack())
                attack();
            cooldowntimer += Time.deltaTime;
        
    }

    public void attack()
    {
        GetComponent<Animator>().SetTrigger("attack");
        cooldowntimer = 0;

        fireballs[Findfireball()].transform.position = firepoint.position;
        fireballs[Findfireball()].GetComponent<fireball>().setdirectioon(Mathf.Sign(transform.localScale.x));
    }

    public int Findfireball()
    {
        for(int i=0; i<fireballs.Length;i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
