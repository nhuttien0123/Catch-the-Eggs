using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public Text hstxt;
    Highscores hsb;
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
        if(hstxt != null)
            hstxt.text = ("High score: " + h);
    }

    public void ClearHS()
    {
        panel.SetActive(true);
        ann.SetActive(true);
    }
    public void Yes()
    {
        hsb = gameObject.GetComponent<Highscores>();
        hsb.ClearHSB();
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
    public int GetRank(int point)
    {
        for(int i = 5; i>0; i--)
        {
            if (point <= PlayerPrefs.GetInt("highscore" + i))
                return i+1;
        }
        return 1;
    }
    public void UpdateHSB(int rank, string name, int point)
    {
        if(rank <= 5)
        {
            for (int i = 5; i > rank; i--)
            {
                SwapRankHS(i, i - 1);
            }
            PlayerPrefs.SetString("name" + rank, name);
            PlayerPrefs.SetInt("highscore" + rank, point);
        }
    }
    public void SwapRankHS(int a, int b)
    {
        string na = "name" + a,
            nb = "name" + b,
            hsa = "highscore" + a,
            hsb = "highscore" + b,
            ntemp;
        int hstemp;
        ntemp = PlayerPrefs.GetString(na); PlayerPrefs.SetString(na, PlayerPrefs.GetString(nb)); PlayerPrefs.SetString(nb,ntemp);
        hstemp = PlayerPrefs.GetInt(hsa); PlayerPrefs.SetInt(hsa, PlayerPrefs.GetInt(hsb)); PlayerPrefs.SetInt(hsb, hstemp);
    }
    public void DeleteRankHS(int rank)
    {
        string nr = "name" + rank, hsr = "highscore" + rank;
        PlayerPrefs.DeleteKey(nr);
        PlayerPrefs.DeleteKey(hsr);
    }

}
