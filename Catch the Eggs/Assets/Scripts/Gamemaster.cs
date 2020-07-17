﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemaster : MonoBehaviour
{
    Basket b;
    float random;
    Sound sound;
    public bool pause = false;

    public GameObject Chicken, Over, Pause;
    public Transform sL, sR;
    public Text pointtxt;
    public int point;
    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<Sound>();
        b = GameObject.FindGameObjectWithTag("Player").GetComponent<Basket>();
    }

    // Update is called once per frame
    void Update()
    {
        pointtxt.text = (" Points: " + point);
        
        //Phím A, S, D tạo thêm Hen, Duck, Goose
        if(Input.GetKeyDown(KeyCode.A))
        {
            random = Random.Range(sL.position.x, sR.position.x);
            GameObject c = Instantiate(Chicken, new Vector2(random, sL.position.y), transform.rotation);
            c.GetComponent<Chicken>().identity=0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            random = Random.Range(sL.position.x, sR.position.x);
            GameObject c = Instantiate(Chicken, new Vector2(random, sL.position.y), transform.rotation);
            c.GetComponent<Chicken>().identity = 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            random = Random.Range(sL.position.x, sR.position.x);
            GameObject c = Instantiate(Chicken, new Vector2(random, sL.position.y), transform.rotation);
            c.GetComponent<Chicken>().identity = 2;
        }


        //Game Pause
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause = true;
            Pause.SetActive(true);
        }
        if(pause)
        {
            Time.timeScale = 0f;
        }
        if(!pause)
        {
            Time.timeScale = 1f;
            Pause.SetActive(false);
        }
    }

    //không hứng egg và shit
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("egg"))
        {
            b.hp--;
            sound.play("brokenegg");
            Destroy(col.gameObject);
        }
        else
            Destroy(col.gameObject);
    }


}
