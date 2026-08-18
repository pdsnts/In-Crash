using UnityEngine;

public class Player : MonoBehaviour
{

    CharacterController controller;

    // Movement variables
    Vector3 forward;
    Vector3 vertical;
    Vector3 strafe;

    // Speed variables
    float forwardSpeed = 5f;
    float strafeSpeed = 5f;

    // Jumping variables
    float gravity;
    float jumpSpeed;
    float maxJumpHeight = 2f;
    float timeToJumpApex = 0.5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timeToJumpApex * timeToJumpApex);
        jumpSpeed = (2 * maxJumpHeight) / timeToJumpApex;
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float strafeInput = Input.GetAxis("Horizontal");

        // force = input * speed * direction
        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;

        vertical += gravity * Time.deltaTime * Vector3.up;

        if (controller.isGrounded)
        {
            vertical = Vector3.down;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            vertical = jumpSpeed * Vector3.up;
        }

        Vector3 finalVelocity = forward + vertical + strafe;
        controller.Move(finalVelocity * Time.deltaTime);
    }
}