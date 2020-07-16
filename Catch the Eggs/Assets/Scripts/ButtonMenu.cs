using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    Gamemaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemaster>();
    }

    public void Play()
    {
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene(1);
    }
    public void SetLevel()
    {
        SceneManager.LoadScene(4);
    }
    public void Help()
    {
        SceneManager.LoadScene(2);
    }
    public void NextHelp()
    {
        SceneManager.LoadScene(3);
    }
    public void Resume()
    {
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
