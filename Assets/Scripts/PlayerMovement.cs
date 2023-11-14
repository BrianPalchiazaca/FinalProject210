using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MouseSensitivity;
    public Transform CamTransform;

    public CharacterController CC;

    private float forwardMovement;
    private float sideMovement;
    private float camRotation = 0f;
    public float walkSpeed;
    private float verticalSpeed;

    public float Gravity = -9.8f;

    public static Transform Clone;
    private void Awake()
    {
        Clone = this.transform;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseInputY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        camRotation -= mouseInputY;
        camRotation = Mathf.Clamp(camRotation, -90f, 90f);
        CamTransform.localRotation = Quaternion.Euler(camRotation, 0f, 0f);

        float mouseInputX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseInputX));


        Vector3 movement = new Vector3();

        forwardMovement = Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime;
        sideMovement = Input.GetAxis("Horizontal") * walkSpeed * Time.deltaTime;

        movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

        if (CC.isGrounded)
        {
            verticalSpeed = 0f;
        }

        verticalSpeed += (Gravity * Time.deltaTime);
        movement += (transform.up * verticalSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            walkSpeed = walkSpeed * 2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && walkSpeed >= 10)
        {
            walkSpeed = walkSpeed / 2f;
        }



        CC.Move(movement);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Destroy(collision.gameObject);
            //health = health - 1;
            Debug.Log("Works");
        }
    }
}
