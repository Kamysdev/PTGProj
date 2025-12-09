using UnityEditor.PackageManager;
using UnityEngine;

public class EventParameters
{
    public Vector3 playerPosition;
    public RaycastHit hitPoint;
    public float impulse;

    public EventParameters(Vector3 playerPosition, RaycastHit hitPoint, float impulse)
    {
        this.playerPosition = playerPosition;
        this.hitPoint = hitPoint;
        this.impulse = impulse;
    }
}
