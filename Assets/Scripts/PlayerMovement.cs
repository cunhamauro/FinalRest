using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    public float walkSpeed = 10f;
    public float sprintSpeed = 15f;
    public float gravity = 20f;
    public float jumpHeight = 30f;
    CharacterController characterController;
    public Vector3 moveDirection = Vector3.zero;
    public Camera playerCamera;
    public Vector2 rotation = Vector2.zero;
    public float lookSpeed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            bool isRunning = Input.GetKey(KeyCode.LeftShift);

            float speedX = (isRunning ? sprintSpeed : walkSpeed) * Input.GetAxis("Horizontal");
            float speedZ = (isRunning ? sprintSpeed : walkSpeed) * Input.GetAxis("Vertical");
            Vector3 right = transform.TransformDirection(Vector3.right);
            Vector3 forward = transform.TransformDirection(Vector3.forward);

            moveDirection = (forward * speedZ) + (right * speedX);

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpHeight; // Set the jump force
            }
        }

        // Apply gravity continuously
        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);

        // Get mouse input
        rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
        rotation.x -= Input.GetAxis("Mouse Y") * lookSpeed; // Invert the Y-axis input

        // Clamp the x rotation to prevent the camera from flipping over
        rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);

        // Apply the rotation to the camera and player
        playerCamera.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        transform.eulerAngles = new Vector3(0, rotation.y, 0);
    }
}