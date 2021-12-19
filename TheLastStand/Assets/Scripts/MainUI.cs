using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : Singleton<MainUI>
{
    public GameObject mainUI;

    //function to enable and disable main game UI
    public void TogglemainUI()
    {
        mainUI.SetActive(!mainUI.activeSelf);
    }
}
