using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBasket : MonoBehaviour
{
    Transform trans;
    public string option;
    public int so;
    public Transform skin1, skin2;
    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey(option))
            so = PlayerPrefs.GetInt(option);
        switch (so)
        {
            case 1: trans.position = skin1.position; break;
            case 2: trans.position = skin2.position; break;
        }    
    }
}
