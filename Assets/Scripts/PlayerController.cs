using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    float forwardSpeed = 10f;
    float horizontalSpeed = 5f;
    float jumpForce = 20f;
    Rigidbody rb;
    Animator animator;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!GameManager.Instance.IsGameRunning)
        {
            return;
        }

        animator.SetBool("Jumping", !IsGrounded());
        MoveForward();
        HandleInput();
    }

    void MoveForward()
    {
        animator.SetBool("Running", true);
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }

    public void StartRunning()
    {
        transform.Rotate(0f, 180f, 0f);
        animator.SetTrigger("Run");
    }
}
