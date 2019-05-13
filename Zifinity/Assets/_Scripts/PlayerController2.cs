using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;

    public GameObject cam;

    int currentDirection = DIRECTION_FORWARD;

    const int DIRECTION_FORWARD = 1;
    const int DIRECRION_BACKWARD = -1;
    const int DIRECTION_LEFT= -2;
    const int DIRECTION_RIGHT = 2;

    public float moveSpeed = 0.3f;
    public float x;
    public float z;

    bool isBackward;

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
    }

    void Movement()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        //Animate(x, z);
       

        if(x != 0 && z == 0)
        {
            if(x > 0)
            {
                if (currentDirection != DIRECTION_RIGHT)
                {
                    ChangeDirection(DIRECTION_RIGHT);
                }
            }
            else
            {
                if (currentDirection != DIRECTION_LEFT)
                {
                    ChangeDirection(DIRECTION_LEFT);
                }
            }
            transform.Translate(Vector3.forward * Mathf.Abs(x) * moveSpeed * Time.deltaTime);
            Animate(0, x);
        }
        else if (z != 0 && x == 0)
        {
            if (z > 0)
            {
                if (currentDirection != DIRECTION_FORWARD)
                {
                    ChangeDirection(DIRECTION_FORWARD);
                }
            }
            else
            {
                if (currentDirection != DIRECRION_BACKWARD)
                {
                    ChangeDirection(DIRECRION_BACKWARD);
                }
            }
            transform.Translate(Vector3.forward * Mathf.Abs(z) * moveSpeed * Time.deltaTime);
            Animate(0, z);

        }
        else 
        {
            Animate(0, 0);
        }


        //Vector3 v3 = new Vector3(0, 0, 0);
        //rb.AddForce(v3);
    }

    void ChangeDirection(int newDirection)
    {
        switch (currentDirection)
        {
            case DIRECTION_FORWARD:
                if(newDirection == DIRECTION_LEFT)
                {
                    transform.Rotate(new Vector3(0, -90, 0));
                }
                else if(newDirection == DIRECTION_RIGHT)
                {
                    transform.Rotate(new Vector3(0, 90, 0));
                }
                else if(newDirection == DIRECRION_BACKWARD)
                {
                    transform.Rotate(new Vector3(0, 180, 0));
                }
                else
                {

                }
                break;
            case DIRECRION_BACKWARD:
                if (newDirection == DIRECTION_LEFT)
                {
                    transform.Rotate(new Vector3(0, 90, 0));

                }
                else if (newDirection == DIRECTION_RIGHT)
                {
                    transform.Rotate(new Vector3(0, -90, 0));

                }
                else if (newDirection == DIRECTION_FORWARD) 
                {
                    transform.Rotate(new Vector3(0, 180, 0));
                }
                else
                {

                }
                break;
            case DIRECTION_RIGHT:
                if (newDirection == DIRECTION_LEFT)
                {
                    transform.Rotate(new Vector3(0, 180, 0));

                }
                else if (newDirection == DIRECTION_FORWARD)
                {
                    transform.Rotate(new Vector3(0, -90, 0));

                }
                else if(newDirection == DIRECRION_BACKWARD)
                {
                    transform.Rotate(new Vector3(0, 90, 0));
                }
                else
                {

                }

                break;
            case DIRECTION_LEFT:
                if (newDirection == DIRECTION_FORWARD)
                {
                    transform.Rotate(new Vector3(0, 90, 0));

                }
                else if (newDirection == DIRECTION_RIGHT)
                {
                    transform.Rotate(new Vector3(0, 180, 0));

                }
                else if(newDirection == DIRECRION_BACKWARD)
                {
                    transform.Rotate(new Vector3(0, -90, 0));
                }
                else
                {

                }
                break;
        }

        currentDirection = newDirection;
    }
    


    void Animate(float X, float Z)
    {
        if (Z != 0)
        {
            anim.SetBool("Walk", true);
            if (Input.GetButton("Jump"))
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }
        //else if (Z < 0)
        //{
        //    if ((int)cam.transform.eulerAngles.y == (int)transform.eulerAngles.y)
        //    {
        //        transform.Rotate(new Vector3(0, 180, 0));
        //        isBackward = true;
        //    }
        //    else
        //    {
        //        isBackward = false;
        //    }
        //    anim.SetBool("Walk", true);
        //    if (Input.GetButton("Jump"))
        //    {
        //        anim.SetBool("Run", true);
        //    }
        //    else
        //    {
        //        anim.SetBool("Run", false);
        //    }
        //}
        else
        {
            anim.SetBool("Walk", false);
        }

        //if (isBackward)
        //{
        //    //X = -X;
        //}

        //transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 50 * X);
        //if(X > 0)
        //{
        //    transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime);
        //}
        //else if (X < 0)
        //{
        //    transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime);
        //}
    }
}
