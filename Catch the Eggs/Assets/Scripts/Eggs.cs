using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggs : MonoBehaviour
{
    Basket b;
    Rigidbody2D r2;
    Animator anim;
    public float speed;
    public bool broken = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        b = GameObject.FindGameObjectWithTag("Player").GetComponent<Basket>();
        speed = b.dropspeed;
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Broken", broken);
        r2.velocity = new Vector2(0, -speed);
        if(broken)
        {
            r2.bodyType = RigidbodyType2D.Static;
            broken = false;
            Destroy(gameObject, 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("GM"))
        {
            broken = true;
        }
    }
}
