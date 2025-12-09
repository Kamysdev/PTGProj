using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform viewTransform;

    [SerializeField] [Range(0, 10)] private float xSensitivity = 5f;
    [SerializeField] [Range(0, 10)] private float ySensitivity = 5f;

    private Quaternion center;

    private void Start() => center = viewTransform.localRotation;

    private void OnLook(InputValue context)
    {
        Vector2 lookDirection = context.Get<Vector2>();
        float mouseX = lookDirection.x * xSensitivity;
        float mouseY = lookDirection.y * ySensitivity;

        Quaternion xQuaternion = Quaternion.AngleAxis(mouseX, Vector3.up) * playerTransform.localRotation;
        Quaternion yQuaternion = Quaternion.AngleAxis(mouseY, Vector3.left) * viewTransform.localRotation;

        if (Quaternion.Angle(center, yQuaternion) < 90f)
            viewTransform.localRotation = yQuaternion;

        playerTransform.localRotation = xQuaternion;
    }
}
