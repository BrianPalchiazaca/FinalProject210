using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
    public float Health;
    public Zombie Zom;

    public int Score = 0;
    public int points = 0;
    public Text ScoreText;

    public PlayerHealth HealthBar;

    public static Transform Clone;

    private void Awake()
    {
        Clone = this.transform;
    }

    //public TextManage GOText;
    public TextManage GOText;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Health = 3;

        ScoreText.text = "Score: " + Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
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


        //Sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            walkSpeed = walkSpeed * 2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && walkSpeed >= 10)
        {
            walkSpeed = walkSpeed / 2f;
        }
        CC.Move(movement);

        //Health system
        if (Health <= 0)
        {
            PlayerDies();
        }

        ScoreText.text = "Score: " + Score.ToString();
    }

    //Detects enemies attack(When an enemy comes to contact with the player.)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombies")
        {
            //Destroy(collision.gameObject);
            HealthBar.TakeDamage(33);
            Health = Health - 1;
            Debug.Log("Ouch");
        }

        if (collision.gameObject.tag == "Enemy2")
        {
            //Destroy(collision.gameObject);
            FindObjectOfType<PlayerHealth>().TakeDamage(33);
            Health = Health - 1;
            Debug.Log("Ouch");
        }
    }

    public void PlayerDies()
    {
        GOText.AppearText();
        Debug.Log("Im dead");
        walkSpeed = 0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore()
    {
        Score += points;
        ScoreText.text = "Score: " + Score.ToString();
    }
}
