using UnityEngine;
using UnityEngine.Events;
using System.Collections; 

public class GunShootingScript : MonoBehaviour
{
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private ShellEjectionScript shellEjection;
    [SerializeField] public UnityEvent eventShot;
    [SerializeField][Range(0.1f, 100f)] private float muzzleDuration = 0.1f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayShootAnimation()
    {
        animator.SetBool("isFiring", true);
    }

    public void ShootStart()
    {
        Debug.Log("Start shooting");
        muzzleFlash.SetActive(true);
        PlayShootAnimation();
        eventShot?.Invoke();
    }

    public void ShootStop()
    {
        Debug.Log("Stop shooting");
        animator.SetBool("isFiring", false);
        StartCoroutine(StopMuzzleAfterDelay(muzzleDuration));
    }

    private IEnumerator StopMuzzleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        muzzleFlash.SetActive(false);
    }

    public void Ejcectionmoment()
    {
        shellEjection.EjectShell();
    }
}
