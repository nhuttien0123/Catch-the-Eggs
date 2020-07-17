using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public Text hstxt;

    public GameObject panel, ann;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHS();
    }
    public void UpdateHS()
    {
        float h = 0;
        if (PlayerPrefs.HasKey("highscore"))
            h = PlayerPrefs.GetInt("highscore");
        hstxt.text = ("High score: " + h);
    }

    public void ClearHS()
    {
        panel.SetActive(true);
        ann.SetActive(true);
    }
    public void Yes()
    {
        PlayerPrefs.DeleteKey("highscore");
        UpdateHS();
        panel.SetActive(false);
        ann.SetActive(false);
    }
    public void No()
    {
        panel.SetActive(false);
        ann.SetActive(false);
    }

}
