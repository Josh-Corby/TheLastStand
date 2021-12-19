using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : Singleton<MainUI>
{
    public GameObject mainUI;

    public void TogglemainUI()
    {
        mainUI.SetActive(!mainUI.activeSelf);
    }
}
