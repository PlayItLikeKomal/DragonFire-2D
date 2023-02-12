using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireball : MonoBehaviour
{
    [SerializeField]private float speed;
   [SerializeField] private float direction;
   [SerializeField] private bool hit;
    private Animator ami;
    private Collider2D col;

    // Start is called before the first frame update
    private void Awake()
    {
        ami = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        float movementspeed = speed * Time.deltaTime * direction;
        transform.Translate(movementspeed, 0, 0);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        hit =true;
        //GetComponent<Collider2D>().enabled = false;
        //GetComponent<Animator>().SetTrigger("explode");
       col.enabled = false;
        ami.SetTrigger("explode");


        if (collision.tag=="enemy")
        {
           
          collision.GetComponent<health>()._takedemage(1);

        }

    }

    public void setdirectioon(float _direction)
    {
       direction = _direction;
       gameObject.SetActive(true);
        hit = false;
      col.enabled = true;

        float localscalex = transform.localScale.x;
        if (Mathf.Sign(localscalex) != _direction)
            localscalex =- localscalex;
        transform.localScale = new Vector3(localscalex, transform.localScale.y, transform.localScale.z);

    }
    public void diactivate()
    {
        gameObject.SetActive(false);
    }
}