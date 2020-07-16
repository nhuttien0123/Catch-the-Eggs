using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Text lv;
    Basket b;

    // Start is called before the first frame update
    void Start()
    {
        b = GameObject.FindGameObjectWithTag("Player").GetComponent<Basket>();
    }

    // Update is called once per frame
    void Update()
    {
        lv.text = ("Level: " + (b.dropspeed - 1));
    }
}
