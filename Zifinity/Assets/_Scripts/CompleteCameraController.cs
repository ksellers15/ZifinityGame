using UnityEngine;
using System.Collections;

public class CompleteCameraController : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object

    public float turnSpeed = 3.0f;
    public float height;
    public float distanceX;
    public float distanceY;


    //private Vector3 offset;
    public Vector3 offsetX;
    public Vector3 offsetY;         

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        //offset = transform.position - player.transform.position;
        offsetX = new Vector3(0, height, distanceX);
        offsetY = new Vector3(0, 0, distanceY);
    }

    private void Update()
    {
        //MoveWithInput();
    }

    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //transform.position = player.transform.position + offset;
        offsetX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offsetX;
        offsetY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * ((offsetY.z == 0) ? new Vector3(0, 0, 0.5f) : offsetY);

        transform.position = player.transform.position + offsetX + offsetY;
        transform.LookAt(player.transform.position);
    }


    void MoveWithInput()
    {
        float x = Input.GetAxis("Mouse X");

        transform.Rotate(new Vector3(0, x, 0) * Time.deltaTime * 10);
    }
}