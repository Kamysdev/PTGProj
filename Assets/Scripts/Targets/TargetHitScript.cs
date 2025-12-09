using UnityEngine;
using UnityEngine.Events;

public class TargetHitScript : MonoBehaviour
{
    public UnityEvent<EventParameters> OnTargetHit;

    public void TargetHit(EventParameters parameters)
    {
        Debug.Log("Target hit detected.");
        OnTargetHit?.Invoke(parameters);
    }
}
