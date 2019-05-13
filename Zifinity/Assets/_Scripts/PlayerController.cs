using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;

    public float turnSpeed;

    public GameObject cam;

    public float camY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //transform.forward = cam.transform.forward;
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Rotate(new Vector3(0, x, 0) * Time.deltaTime * turnSpeed);


        //if (anim.GetBool("Run") && Input.GetKeyDown(KeyCode.J))
        //{
        //    anim.SetTrigger("Jump");
        //}

        if (z > 0)
        {

            if (Mathf.Abs(x) > 0)
            {
                //cam.transform.rotation = Quaternion.Euler(cam.transform.rotation.eulerAngles.x, transform.eulerAngles.y, cam.transform.rotation.eulerAngles.z);
                if (x < 0)
                    anim.SetBool("TurnLeft", true);
                else
                    anim.SetBool("TurnRight", true);
            }
            else
            {
                RotateWithCameraForward();
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", false);
            }


            anim.ResetTrigger("TurnAround");

            anim.SetBool("Walk", true);
            if (Input.GetButton("Sprint") || Input.GetAxis("Sprint") > 0)
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }
        else if (z < 0) // change this in relation to camera
        {
            MoveBackwardWithCamera();
            if (Mathf.Abs(x) > 0)
            {
                if (x < 0)
                    anim.SetBool("TurnLeft", true);
                else
                    anim.SetBool("TurnRight", true);
            }
            else
            {
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", false);
            }


            anim.ResetTrigger("TurnAround");

            anim.SetBool("Walk", true);
            if (Input.GetButton("Sprint"))
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);

            if (x != 0)
            {
                transform.Rotate(new Vector3(0, x, 0) * Time.deltaTime * turnSpeed);
            }
        }

    }


    void RotateWithCameraForward()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.rotation.eulerAngles.z), turnSpeed * 5 * Time.deltaTime);

    }

    void MoveBackwardWithCamera()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, 180 + Camera.main.transform.eulerAngles.y, -transform.rotation.eulerAngles.z), turnSpeed * 5 * Time.deltaTime);

    }
}
