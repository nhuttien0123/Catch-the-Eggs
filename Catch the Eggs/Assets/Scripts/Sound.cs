using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip catchegg, catchshit, gameover, brokenegg;
    public AudioSource ads;
    // Start is called before the first frame update
    void Start()
    {
        ads = gameObject.GetComponent<AudioSource>();
        catchegg = Resources.Load<AudioClip>("catchegg");
        catchshit = Resources.Load<AudioClip>("catchshit");
        gameover = Resources.Load<AudioClip>("gameover");
        brokenegg = Resources.Load<AudioClip>("brokenegg");
    }

    public void play(string clip)
    {
        switch(clip)
        {
            case "catchegg": ads.PlayOneShot(catchegg,1.4f); break;
            case "catchshit": ads.PlayOneShot(catchshit); break;
            case "gameover": ads.PlayOneShot(gameover); break;
            case "brokenegg": ads.PlayOneShot(brokenegg); break;
        }
    }
}
