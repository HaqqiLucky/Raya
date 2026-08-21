using UnityEngine;
using UnityEngine.InputSystem;

public class RayaWASD : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        }
        else if (moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f,0f,0f);
        }
        if (context.performed)
        {
            animator.SetFloat("Blend", 1);
            
        }
        if (context.canceled)
        {
            animator.SetFloat("Blend", 0);
        }

    }

}
