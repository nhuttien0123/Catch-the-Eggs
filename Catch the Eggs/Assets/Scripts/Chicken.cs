using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    Rigidbody2D r2;
    Animator anim;
    public GameObject egg, shit;
    public int identity;
    public float speed, drop, interval, random;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        anim.SetInteger("Iden", identity);
        r2.velocity = new Vector2(speed, 0);
        drop += Time.deltaTime;

        //thả egg và shit ngẫu nhiên
        if(drop >= interval)
        {
            drop = 0;
            random = Random.value;
            if (random < 0.5)
                Instantiate(egg, transform.position, transform.rotation);
            else
                Instantiate(shit, transform.position, transform.rotation);
        }
    }

    //đổi hướng
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DC"))
            speed *= -1;

    }
}
