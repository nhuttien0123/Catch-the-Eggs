using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallen : MonoBehaviour
{
    Rigidbody2D r2;
    public float speed;
    Basket b;
    // Start is called before the first frame update
    void Start()
    {
        b = GameObject.FindGameObjectWithTag("Player" +
            "").GetComponent<Basket>();
        speed = b.dropspeed;
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        r2.velocity = new Vector2(0, -speed);
    }
}
