using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private InputAction _moveAction;

    [SerializeField] private PlayerInput _inputActions;
    [SerializeField] private InputAction _interactAction;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator playerAnimator;


    private void Awake()
    {
        _interactAction = _inputActions.actions["Interact"];
        _interactAction.performed += _ => OnInteract();

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

    }

    private void Update()
    {

    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }


    private void FixedUpdate()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
        rb.velocity = playerVelocity;
        
        if(!playerAnimator) return;
        
        if (moveInput.x > 0)
        {
            playerAnimator.SetFloat("Horizontal", 1);
        }
        else if (moveInput.x < 0)
        {
            playerAnimator.SetFloat("Horizontal", -1);
        }
        
        if (moveInput.y > 0)
        {
            playerAnimator.SetFloat("Vertical", 1);
        }
        else if (moveInput.y < 0)
        {
            playerAnimator.SetFloat("Vertical", -1);
        }
        
        if (moveInput.x == 0 && moveInput.y == 0)
        {
            playerAnimator.SetFloat("Horizontal", 0);
            playerAnimator.SetFloat("Vertical", 0);
        }
    }
    void OnInteract()
    {

    }
}
