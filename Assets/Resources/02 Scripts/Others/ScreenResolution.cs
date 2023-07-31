using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    void Awake()
    {
        Screen.SetResolution(1024, 1024, FullScreenMode.FullScreenWindow);
    }

}
