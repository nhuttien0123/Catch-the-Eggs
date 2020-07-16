using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetLevel : MonoBehaviour
{
    public int level;

    // Update is called once per frame
    public void SetLv()
    {
        PlayerPrefs.SetInt("level", level);
        SceneManager.LoadScene(1);
    }
}
