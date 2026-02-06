using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 150f;
    [SerializeField] private Animator animator;

    private Rigidbody rb;
    private PlayerInput playerInput;
    private Vector2 input;
    private bool isMoving;
    private bool isMovingFlag = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        rb.freezeRotation = true; // evita que caigui de costat
    }

    void Update()
    {
        input = playerInput.actions["Move"].ReadValue<Vector2>();
        isMoving = input.sqrMagnitude > 0.01f;

        if (isMovingFlag != isMoving)
        {
            isMovingFlag = isMoving;
            animator.SetBool("a", isMoving);
        }

        // Rotació cap a la direcció del moviment
        if (isMoving)
        {
            Vector3 direction = new Vector3(input.x, 0f, input.y);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(direction),
                10f * Time.deltaTime
            );
        }
    }

    private void FixedUpdate()
    {
        // Moviment amb velocitat directa
        Vector3 moveDir = new Vector3(input.x, 0f, input.y).normalized;
        Vector3 newVelocity = new Vector3(moveDir.x * moveSpeed, rb.linearVelocity.y, moveDir.z * moveSpeed);

        rb.linearVelocity = newVelocity;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            rb.AddForce(Vector3.up * jumpForce);
    }
}
