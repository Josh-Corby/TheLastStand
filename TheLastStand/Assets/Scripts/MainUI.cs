using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUI : Singleton<MainUI>
{
    public GameObject mainUI;
    public TMP_Text waveCount;

    //function to enable and disable main game UI
    public void TogglemainUI()
    {
        mainUI.SetActive(!mainUI.activeSelf);
    }

}
