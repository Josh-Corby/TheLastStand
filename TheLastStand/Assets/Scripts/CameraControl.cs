using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : GameBehaviour
{
    public PlayerController thePlayer;
    private Vector3 pos;
    //offset for how high the camera is to the player
    public int cameraYOffset;
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    //function to make the camera follow the player
    void Update()
    {
        pos = new Vector3(thePlayer.transform.position.x, cameraYOffset, thePlayer.transform.position.z);
        transform.position = pos;
    }
}
