using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVolume : MonoBehaviour
{
    Animator anim;

    public int vol = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        if(PlayerPrefs.HasKey("volume"))
        {
            vol = PlayerPrefs.GetInt("volume");
        }
    }
    void Update()
    {
        anim.SetInteger("Vol", vol);
    }
    public void Mute()
    {
        
        if(vol == 0)
        {
            vol = 1;
            PlayerPrefs.SetInt("volume", 1);
        }
        else
        {
            vol = 0;
            PlayerPrefs.SetInt("volume", 0);
        }
    }
}
