using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    // Components
    private CharacterController controller;

    // Movement
    private Vector3 playerVelocity = Vector3.zero;
    private float speed = 1.5f;
    public float gravity = -9.8f;

    // Jump
    private bool isGrounded;
    public float jumpHeight = 1.5f;

    // Crouch
    private bool crouching = false;
    private bool lerpCrouch = false;
    private float crouchTimer;

    // Sprint
    public bool sprinting;
    public float walkSpeed = 1.5f;
    public float sprintSpeed = 2.5f;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;

        // Crouching
        if(lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;

            if(crouching)
                controller.height = Mathf.Lerp(controller.height, 1 , p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if(p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    // Receives inputs from InputManager and apply to the character controller.
    public void ProcessMovement(Vector2 input)
    {

        // Move Player by getting input from the InputManager.
        Vector3 moveDirection = new Vector3(input.x, 0, input.y);
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        
        // Increase Gravitational force constantly
        playerVelocity.y += gravity * Time.deltaTime;

        // If player is grounded, set the gravitational force to constant value.
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        // Apply all movements (Horizontal & Gravitaional)
        controller.Move((transform.TransformDirection(moveDirection) * speed * Time.deltaTime) + (playerVelocity * Time.deltaTime));
    }

    public void Jump()
    {
        if (isGrounded)
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void Sprint()
    {
        sprinting = !sprinting;

        if (sprinting)
            speed = sprintSpeed;
        else
            speed = walkSpeed;
    }
}
