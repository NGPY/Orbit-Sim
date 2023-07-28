using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float AngleX;
    public float AngleY;
    public bool Focus;
    private int Delay;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Focus = true;
        Delay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Camera movement for horizontal movement
        float cameraVerticalInput = Input.GetAxis("Vertical");
        float cameraHorizontalInput = Input.GetAxis("Horizontal");

        Vector3 forward = this.transform.forward;
        Vector3 right = this.transform.right;

        Vector3 forwardRelativeVerticalInput = cameraVerticalInput * forward;
        Vector3 rightRelativeHorizontalInput = cameraHorizontalInput * right;

        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput / 2 + rightRelativeHorizontalInput / 2;

        // Camera movement for vertical movement
        Vector3 UpDown = new Vector3(0, Input.GetAxis("Up") / 2, 0);

        cameraRelativeMovement = UpDown + cameraRelativeMovement;

        transform.position += cameraRelativeMovement;


        // Camera moving with mouse
        var angles = transform.localEulerAngles;
        var xAxis = Input.GetAxis("Mouse X");
        var yAxis = Input.GetAxis("Mouse Y");

        
        if (Focus)
        {
            AngleX = AngleX - yAxis;
            AngleY = AngleY + xAxis;


            angles.y = AngleY;
            if (AngleX > 90)
            {
                angles.x = 90;
                AngleX = 90;
            }
            if (AngleX < -90)
            {
                angles.x = -90;
                AngleX = -90;
            }
            else
            {
                angles.x = AngleX;
            }
            transform.localRotation = Quaternion.Euler(angles);

            transform.localEulerAngles = angles;
        }
        var Foc = Input.GetAxis("Cancel");
        if (Foc > 0 && Delay < 0)
        {
            Delay = 20;
            Focus = !Focus;
            Cursor.visible = !Cursor.visible;
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
        Delay--;

        // Zooming in with scroll wheel
        //var Scroll = Input.GetAxis("Mouse ScrollWheel");
        //if (Camera.main.fieldOfView < 90)
        //{
        //    Camera.main.fieldOfView -= Scroll * 10;
        //}
        //else
        //{
        //    Camera.main.fieldOfView = 89.99F;
        //}

        // Changing the time scale with the scroll wheel
        var Scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Time.timeScale < 0.5f) 
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale += Convert.ToSingle(Math.Round(Scroll, 1));
        }
    }
}
