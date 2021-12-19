using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{

    public float moveSpeed;
    private Rigidbody rb;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunControl gun;

    public bool useController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }


    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;


        //Ray used to find point where mouse is pointing at
        if (!useController)
        {
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;
            //function used to make the player look where the mouse is pointing
            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }

            if (Input.GetMouseButtonDown(0))
            {
                gun.isFiring = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                gun.isFiring = false;
            }
        }

        //Rotate with Controller
        if(useController)
        {
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical");
            if(playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button5))
            {
                gun.isFiring = true;
            }
            if (Input.GetKeyUp(KeyCode.Joystick1Button5))
            {
                gun.isFiring = false;
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }
}
