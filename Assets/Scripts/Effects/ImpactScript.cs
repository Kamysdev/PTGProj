using UnityEngine;

public class ImpactScript : MonoBehaviour
{
    [SerializeField][Range(0f, 5f)] private float duration = 2f;
    [SerializeField] private GameObject impactEffectPrefab;

    public void PlayImpactEffect(EventParameters parameters)
    {
        if (impactEffectPrefab != null)
        {
            Quaternion rotation = Quaternion.LookRotation(parameters.hitPoint.normal);
            GameObject impactEffect = Instantiate(impactEffectPrefab, parameters.hitPoint.point, rotation);
            Destroy(impactEffect, duration);
        }
    }
}
