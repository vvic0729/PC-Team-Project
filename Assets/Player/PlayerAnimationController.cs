using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public float mouseSensitivityX = 100f;
    public float mouseSensitivityY = 50f;
    private CharacterController characterController;
    private float xRotation = 0f;
    private float yRotation = 0f;
    private Animator animator;
    public Transform playerCamera;
    public float playerRunningSpeed = 16f;
    public float playerStrafeSpeed = 6f;
    public float defaultPlayerSpeed = 8f;
    public float playerSpeed = 0f;
    public int playerHp = 100;
    public string playerName = "PlayerName";

    void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        playerSpeed = defaultPlayerSpeed;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
        HandleAnimations();
        HandleHealth();
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        yRotation -= mouseY;
        xRotation -= mouseX;
        yRotation = Mathf.Clamp(yRotation, -60f, 40f);

        playerCamera.localRotation = Quaternion.Euler(0, yRotation, 90f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = playerRunningSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            playerSpeed = playerStrafeSpeed;
        }
        else
        {
            playerSpeed = defaultPlayerSpeed;
        }

        characterController.Move(move * playerSpeed * Time.deltaTime);
    }

    private void HandleAnimations()
    {
        HandleMovementAnimations();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("IsJump");
        }
    }

     private void HandleMovementAnimations()
    {
        bool isWalking = false;

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsForward", true);
            isWalking = true;
        }
        else
        {
            animator.SetBool("IsForward", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsLeft", true);
            isWalking = true;
        }
        else
        {
            animator.SetBool("IsLeft", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsBackward", true);
            isWalking = true;
        }
        else
        {
            animator.SetBool("IsBackward", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsRight", true);
            isWalking = true;
        }
        else
        {
            animator.SetBool("IsRight", false);
        }

        animator.SetBool("IsWalk", isWalking);
    }

    private void HandleHealth()
    {
        if (playerHp <= 0)
        {
            animator.SetBool("Died", true);
            Destroy(gameObject);
        }
    }
}
