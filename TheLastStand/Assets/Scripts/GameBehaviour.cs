using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    //Singletons used in this project
    protected static GameManager _GM { get { return GameManager.instance; } }
    protected static EnemyManager _EM { get { return EnemyManager.instance; } }
    protected static UIManager _UI { get { return UIManager.instance; } }
    protected static PlayerHealth _P { get { return PlayerHealth.instance; } }
    protected static PlayerController _PC { get { return PlayerController.instance; } }
    protected static UpgradesManager _UM { get { return UpgradesManager.instance; } }
}
