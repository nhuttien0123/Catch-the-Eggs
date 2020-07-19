using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemaster : MonoBehaviour
{
    Basket b;
    float random;
    Sound sound;
    Highscore hs;
    public bool pause = false;

    public GameObject Chicken, Over, OverHS, Pause;
    public Transform sL, sR;
    public Text pointtxt, ranktxt, nametxt;
    public int point;
    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<Sound>();
        b = GameObject.FindGameObjectWithTag("Player").GetComponent<Basket>();
        hs = gameObject.GetComponent<Highscore>();
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
        }
        if(pause)
        {
            Time.timeScale = 0f;
            b.isMoving = false;
            if(Pause != null)
                Pause.SetActive(true);
        }
        if(!pause)
        {
            Time.timeScale = 1f;
            if (Pause != null)
                Pause.SetActive(false);
        }

        if (b.hp == 0)
        {
            StartCoroutine(GameOver());
        }
    }

    //không hứng egg và shit
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("egg"))
        {
            b.hp--;
            sound.play("brokenegg");
        }
        //else
            //Destroy(col.gameObject);
    }
    IEnumerator GameOver()
    {
        int r = hs.GetRank(point);
        if (r <= 5)
        {
            ranktxt.text = "Rank: " + r;
            OverHS.SetActive(true);
        }
        else
        {
            Over.SetActive(true);
        }
        if (point > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", point);
        }
        b.hp--;

        sound.play("gameover");
        Destroy(Pause);
        yield return new WaitForSeconds(0.1f);
        pause = true;
        yield return 0;
    }
    public void SaveHS()
    {
        hs.UpdateHSB(hs.GetRank(point), nametxt.text, point);
        SceneManager.LoadScene(0);
    }

}
