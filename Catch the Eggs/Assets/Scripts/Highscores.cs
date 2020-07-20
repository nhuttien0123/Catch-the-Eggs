using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscores : MonoBehaviour
{
    public Text tn1, tn2, tn3, tn4, tn5, ths1, ths2, ths3, ths4, ths5; 
    // Start is called before the first frame update
    void Start()
    {
        tn1.text = "1. " + PlayerPrefs.GetString("name1");
        tn2.text = "2. " + PlayerPrefs.GetString("name2");
        tn3.text = "3. " + PlayerPrefs.GetString("name3");
        tn4.text = "4. " + PlayerPrefs.GetString("name4");
        tn5.text = "5. " + PlayerPrefs.GetString("name5");
        ths1.text = "" + PlayerPrefs.GetInt("highscore1");
        ths2.text = "" + PlayerPrefs.GetInt("highscore2");
        ths3.text = "" + PlayerPrefs.GetInt("highscore3");
        ths4.text = "" + PlayerPrefs.GetInt("highscore4");
        ths5.text = "" + PlayerPrefs.GetInt("highscore5");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearHSB()
    {
        for(int i = 1; i<6; i++)
        {
            PlayerPrefs.DeleteKey("name" + i);
            PlayerPrefs.DeleteKey("highscore" + i);
        }
        tn1.text = "1. " + PlayerPrefs.GetString("name1");
        tn2.text = "2. " + PlayerPrefs.GetString("name2");
        tn3.text = "3. " + PlayerPrefs.GetString("name3");
        tn4.text = "4. " + PlayerPrefs.GetString("name4");
        tn5.text = "5. " + PlayerPrefs.GetString("name5");
        ths1.text = "" + PlayerPrefs.GetInt("highscore1");
        ths2.text = "" + PlayerPrefs.GetInt("highscore2");
        ths3.text = "" + PlayerPrefs.GetInt("highscore3");
        ths4.text = "" + PlayerPrefs.GetInt("highscore4");
        ths5.text = "" + PlayerPrefs.GetInt("highscore5");
    }
}
