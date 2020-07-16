using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    Rigidbody2D r2;
    Vector3 mouseclick, clickposition;
    Animator hpanim;
    bool isMoving;

    Gamemaster gm;
    public int hp,eggs;
    public float speed, h, dropspeed;
    // Start is called before the first frame update
    void Start()
    {
        dropspeed = 2;
        if (PlayerPrefs.HasKey("level"))
            dropspeed = PlayerPrefs.GetInt("level") + 1;
        hpanim = GameObject.FindGameObjectWithTag("HP").GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemaster>();
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hpanim.SetInteger("HP", hp);

        if(eggs == 20)
        {
            dropspeed += 1;
            eggs = 0;
        }

        //Xác định vị trí click chuột
        if (Input.GetMouseButtonDown(0))
        {
            clickposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseclick = new Vector3(clickposition.x, transform.position.y, transform.position.z);
            isMoving = true;
        }
        //Di chuyển bằng chuột
        if (isMoving)
            MoveClick();

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
            r2.velocity = new Vector2(0, 0);

        
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
        }
        if (col.CompareTag("shit"))
        {
            gm.point--;
            hp--;
            Destroy(col.gameObject);
        }
    }
}
