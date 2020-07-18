using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBasket : MonoBehaviour
{
    public void Skin1()
    {
        PlayerPrefs.SetInt("skin", 1);
    }
    public void Skin2()
    {
        PlayerPrefs.SetInt("skin", 2);
    }
}
