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


    private void Awake()
    {
        _interactAction = _inputActions.actions["Interact"];
        _interactAction.performed += _ => OnInteract();

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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
    }
    void OnInteract()
    {

    }
}
