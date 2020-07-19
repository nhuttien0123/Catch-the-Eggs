using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip catchegg, catchshit, gameover, brokenegg;
    public AudioSource ads;
    public int volume = 1;
    // Start is called before the first frame update
    void Start()
    {
        ads = gameObject.GetComponent<AudioSource>();
        catchegg = Resources.Load<AudioClip>("catchegg");
        catchshit = Resources.Load<AudioClip>("catchshit");
        gameover = Resources.Load<AudioClip>("gameover");
        brokenegg = Resources.Load<AudioClip>("brokenegg");
    }
    private void Update()
    {
        if(PlayerPrefs.HasKey("volume"))
            volume = PlayerPrefs.GetInt("volume");
    }

    public void play(string clip)
    {
        switch(clip)
        {
            case "catchegg": ads.PlayOneShot(catchegg,2*volume); break;
            case "catchshit": ads.PlayOneShot(catchshit, volume); break;
            case "gameover": ads.PlayOneShot(gameover, volume); break;
            case "brokenegg": ads.PlayOneShot(brokenegg, volume); break;
        }
    }
}
