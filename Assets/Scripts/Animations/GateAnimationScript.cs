using UnityEngine;

public class GateAnimationScript : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenGate()
    {
        if (!isOpen)
        {
            animator.SetBool("isOpen", true);
            isOpen = true;
        }
    }

    public void CloseGate()
    {
        if (isOpen)
        {
            animator.SetBool("isOpen", false);
            isOpen = false;
        }
    }

}
