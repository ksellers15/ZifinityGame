using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform FollwObject;
    public float CameraSpeed = 120.0f;
    public float rotX;
    public float rotY;
    public float inputSensitivity;
    public float finalInputX;
    public float finalInputZ;

    public float clampAngleX;
    public float clampAngleY;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rotX = rot.x;
        rotY = rot.y;
        transform.forward = FollwObject.forward;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputY = Input.GetAxis("RightStickVertical");

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        finalInputX = mouseX + inputX;
        finalInputZ = mouseY + inputY;

        rotX += finalInputZ * inputSensitivity * Time.deltaTime;
        rotY += finalInputX * inputSensitivity * Time.deltaTime;


        rotX = Mathf.Clamp(rotX, -clampAngleX, clampAngleX);

        Quaternion localPos = Quaternion.Euler(rotX, rotY, 0.0f);

        transform.rotation = localPos;
    }

    void LateUpdate()
    {
        float step = CameraSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, FollwObject.position, step);
    }
}
