using UnityEngine;
using UnityEngine.Events;

public class HPScript : MonoBehaviour
{
    public UnityEvent OnDeath;
    private bool dead = false;

    public void TakeDamage()
    {
        if (dead == false) OnDeath?.Invoke();
        dead = true;
    }
}