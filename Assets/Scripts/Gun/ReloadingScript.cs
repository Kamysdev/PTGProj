using UnityEngine;
using UnityEngine.Events;

public class ReloadingScript : MonoBehaviour
{
    private Animator animator;
    public UnityEvent OnReloadingEnd;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayReoadingAnimation()
    {
        animator.SetTrigger("isReloading");
    }

    public void ReloadingEnd()
    {
        Debug.Log("[ReloadingScript] Reloading End");
        animator.SetBool("isReloading", false);
        OnReloadingEnd?.Invoke();
    }
}
