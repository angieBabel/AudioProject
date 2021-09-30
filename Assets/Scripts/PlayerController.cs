using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController controller;

    public Transform cam;
    public float lookSensitivity;
    public float minXRot;
    public float maxXRot;
    private float curXRot;


    
    // Start is called before the first frame update
    void Start()
    {
        //Hide Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        dir.Normalize();

        dir *= moveSpeed * Time.deltaTime;
        controller.Move(dir);

    }

    void Look()
    {
        //Get the X and Y mouse inputs
        float x = Input.GetAxis("Mouse X") * lookSensitivity;
        float y = Input.GetAxis("Mouse Y") * lookSensitivity;

        //Rotate the player
        transform.eulerAngles += Vector3.up * x;


        curXRot += y;
        curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);

        cam.localEulerAngles = new Vector3(-curXRot, 0.0f, 0.0f);
    }
}
