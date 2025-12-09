using UnityEngine;
using UnityEngine.Events;

public class AnimatedTargetScript : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTargetHit;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TargetReady()
    {
        animator.SetBool("isHit", false);
        animator.SetBool("isReady", true);
    }

    public void TargetHit()
    {
        animator.SetBool("isReady", false);
        animator.SetBool("isHit", true);
    }

    public void OnHit()
    {
        OnTargetHit?.Invoke();
    }
}
