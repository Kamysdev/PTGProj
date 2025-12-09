using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] private GunScript gunScript;

    private void OnAttack()
    {
        gunScript.Shoot();
    }

    private void OnReload()
    {
        gunScript.ReloadingStart();
    }
    

    // [SerializeField] private Camera playerCamera;
    // [SerializeField] [Range(0f, 10f)] private float impulse = 5f;

    // private void OnAttack()
    // {
    //     Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
    //     RaycastHit hit;

    //     if (Physics.Raycast(ray, out hit))
    //     {
    //         ImpactScript impactScript = hit.transform.GetComponent<ImpactScript>();
    //         if (impactScript != null)
    //         {
    //             Debug.Log("Hit " + hit.transform.name);
    //             impactScript.PlayImpactEffect(new EventParameters(transform.position, hit, impulse));
    //         }

    //         if (hit.transform.CompareTag("Target"))
    //         {
    //             TargetHitScript targetHitScript = hit.transform.GetComponent<TargetHitScript>();
    //             if (targetHitScript != null)
    //             {
    //                 EventParameters parameters = new EventParameters(transform.position, hit, impulse);
    //                 targetHitScript.TargetHit(parameters);
    //             }
    //         }
    //     }
    // }
}
