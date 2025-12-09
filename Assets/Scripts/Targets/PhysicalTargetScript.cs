using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicalTargetScript : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnHit(EventParameters parameters)
    {
        Vector3 forceDirection = (transform.position - parameters.hitPoint.point).normalized;

        rb.AddForceAtPosition(forceDirection * parameters.impulse, parameters.hitPoint.point, ForceMode.Impulse);
    }
}
