using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    Gamemaster gm;

    public void Play()
    {
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene(1);
    }
    
    public void Help()
    {
        SceneManager.LoadScene(2);
    }
    public void NextHelp()
    {
        SceneManager.LoadScene(3);
    }
    public void SetLevel()
    {
        SceneManager.LoadScene(4);
    }
    public void Basket()
    {
        SceneManager.LoadScene(5);
    }
    public void HighscoreBoard()
    {
        SceneManager.LoadScene(6);
    }
    public void Resume()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemaster>();
        gm.pause = false;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
