using UnityEngine;

public class GunLogic : MonoBehaviour
{
    [SerializeField] private Transform firingPoint;
    [SerializeField][Range(1f, 100f)] private float impulse;

    public void Shoot()
    {
        Ray ray = new Ray(firingPoint.transform.position, firingPoint.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            ImpactScript impactScript = hit.transform.GetComponent<ImpactScript>();
            if (impactScript != null)
            {
                Debug.Log("Hit " + hit.transform.name);
                impactScript.PlayImpactEffect(new EventParameters(transform.position, hit, impulse));
            }

            if (hit.transform.CompareTag("Target"))
            {
                TargetHitScript targetHitScript = hit.transform.GetComponent<TargetHitScript>();
                if (targetHitScript != null)
                {
                    EventParameters parameters = new EventParameters(transform.position, hit, impulse);
                    targetHitScript.TargetHit(parameters);
                }
            }
        }
    }
}
