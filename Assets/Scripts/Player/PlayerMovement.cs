using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private float moveSpeed = 5f;
    [SerializeField] [Range(0, 10)] private float jumpForce = 5f;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float gravity = -9.81f;

    private Vector3 direction = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private bool isGrounded = true;

    private void OnMove(InputValue context)
    {
        Vector2 moveDirection = context.Get<Vector2>();

        direction = new Vector3(moveDirection.x, 0, moveDirection.y).normalized;
    }
    
    private void OnJump(InputValue context)
    {
        if (isGrounded)
            velocity.y += Mathf.Sqrt(jumpForce * -3f * gravity);
    }

    public void HitJump()
    {
        if (isGrounded)
            velocity.y += Mathf.Sqrt(jumpForce * -3f * gravity);
    }

    private void LateUpdate()
    {
        isGrounded = characterController.isGrounded;
        characterController.Move(transform.TransformDirection(direction) * (moveSpeed * Time.deltaTime));

        if (isGrounded && velocity.y < 0)
            velocity.y = 0;

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}
