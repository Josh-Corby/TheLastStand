using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : Singleton<ShopMenu>
{

    public TMP_Text[] upgradeCosts;


    void Start()
    {
        int i = 0;
        while (i < upgradeCosts.Length)
        {
            upgradeCosts[i].text = _UM.shopCosts[i].ToString();
            i++;
        }
    }
}
