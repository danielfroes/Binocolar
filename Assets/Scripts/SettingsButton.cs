using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    private void Awake() 
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }

    public void SetFullscreen(bool status){
        if(status)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
    public void SetMute(bool status)
    {
        AudioListener.pause = status;
    }
}
