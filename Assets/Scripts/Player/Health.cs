using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] int maximumHealth = 100;
    [Range(1, 100)]
    [SerializeField] int currentHealth = 100;

    public UnityEvent<int, int> onHealthChange;

    public UnityEvent<Vector3> spawnOnDeath;
    public UnityEvent onDeath;
    public UnityEvent onHitTaken;


    void Start() => onHealthChange?.Invoke(currentHealth, maximumHealth);

    public bool changeHealth(int amount)
    {
        if (currentHealth == maximumHealth) 
            return false;

        currentHealth += amount;

        if (currentHealth > maximumHealth)
            currentHealth = maximumHealth;

        if (currentHealth < 0)
            currentHealth = 0;

        onHealthChange?.Invoke(currentHealth, maximumHealth);

        return true;
    }

    public void hpDecrease(float amount)
    {
        if (currentHealth <= 0) return;

        onHitTaken?.Invoke();

        currentHealth = Mathf.FloorToInt(currentHealth - amount);

        if (currentHealth < 0)
            currentHealth = 0;

        onHealthChange?.Invoke(currentHealth, maximumHealth);

        if (currentHealth <= 0)
        {
            onDeath?.Invoke();
            spawnOnDeath?.Invoke(transform.position);
        }
    }
}
