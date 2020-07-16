using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleResolution : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        ScaleResolutionScreen();
    }
    //chỉnh tỉ lệ màn hình
    void ScaleResolutionScreen()
    {
        if ((Screen.height / Screen.width) > (16 / 9))
        {
            int sw = Screen.width, sh = sw * 16 / 9;
            Screen.SetResolution(sw, sh, FullScreenMode.Windowed);
        }
        if ((Screen.height / Screen.width) < (16 / 9))
        {
            int sh = Screen.height, sw = sh / 16 * 9;
            Screen.SetResolution(sw, sh, FullScreenMode.Windowed);
        }
    }
}
