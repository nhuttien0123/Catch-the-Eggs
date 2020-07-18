using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    Rigidbody2D r2;
    Vector3 mouseclick, clickposition;
    Animator hpanim, anim;
    bool isMoving;
    Sound sound;
    int skin = 0;

    Gamemaster gm;
    public int hp,eggs;
    public float speed, h, dropspeed;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<Sound>();
        dropspeed = 2;
        if (PlayerPrefs.HasKey("level"))
        { 
            dropspeed = PlayerPrefs.GetInt("level") + 1;
        }
        if (PlayerPrefs.HasKey("skin"))
        {
            skin = PlayerPrefs.GetInt("skin");
        }
        hpanim = GameObject.FindGameObjectWithTag("HP").GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemaster>();
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("Skin", skin);
        hpanim.SetInteger("HP", hp);

        if (hp == 0)
        {
            GameOver();
        }

        if (eggs == 20)
        {
            dropspeed += 1;
            eggs = 0;
        }

        //Xác định vị trí click chuột
        if (Input.GetMouseButtonDown(0))
        {
            clickposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseclick = new Vector3(clickposition.x, transform.position.y, transform.position.z);
            isMoving = true; Debug.Log("Click");
        }
        //Di chuyển bằng chuột
        if (isMoving)
        { 
            MoveClick();
        }

        //Di chuyển bằng phím
        if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.RightArrow)) 
        {
            isMoving = false;
            r2.velocity = new Vector2(speed, 0);
        }
        if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.LeftArrow))
        {
            isMoving = false;
            r2.velocity = new Vector2(-speed, 0);
        }
        if (Input.GetKeyUp(KeyCode.Keypad6) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.Keypad4) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            r2.velocity = new Vector2(0, 0); Debug.Log("Up");
        }

        
    }
    void MoveClick()
    {
        transform.position = Vector2.MoveTowards(transform.position, mouseclick, speed * Time.deltaTime);
        if(transform.position == mouseclick || h!=0)
        {
            isMoving = false; 
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("egg"))
        { 
            gm.point++;
            eggs++;
            Destroy(col.gameObject);
            sound.play("catchegg");
        }
        if (col.CompareTag("shit"))
        {
            gm.point--;
            hp--;
            Destroy(col.gameObject);
            if(hp>0.5f)
                sound.play("catchshit");
        }
    }

    void GameOver()
    {
        gm.Over.SetActive(true);
        if (gm.point > PlayerPrefs.GetInt("highscore"))
        { 
            PlayerPrefs.SetInt("highscore", gm.point);
        }
        
        gm.pause = true; hp--;
        sound.play("gameover");
    }
}
