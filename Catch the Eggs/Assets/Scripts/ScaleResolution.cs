using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleResolution : MonoBehaviour
{
    bool isWider;
    float gameratio, screenratio;
    public SpriteRenderer back;
    // Start is called before the first frame update
    void Start()
    {
        screenratio = (float)Screen.width / (float)Screen.height;
        gameratio = 9f / 16f;
        if (screenratio < gameratio)
            isWider = true;
        else
            isWider = false;
        if (back != null)
        {
            if (isWider)
                Camera.main.orthographicSize = back.bounds.size.x;
            else
                Camera.main.orthographicSize = back.bounds.size.y / 2;
        }
        Screen.fullScreenMode = FullScreenMode.Windowed;
        
    }
}
