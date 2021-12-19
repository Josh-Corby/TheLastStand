using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : GameBehaviour
{
    public PlayerController thePlayer;
    private Vector3 pos;
    public int cameraYOffset;
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        pos = new Vector3(thePlayer.transform.position.x, cameraYOffset, thePlayer.transform.position.z);
        transform.position = pos;
    }
}
