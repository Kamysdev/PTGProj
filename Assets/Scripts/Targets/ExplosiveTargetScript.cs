using UnityEngine;

public class ExplosiveTargetScript : MonoBehaviour
{
    [SerializeField][Range(0f, 5f)] private float duration = 1f;
    [SerializeField] GameObject explosionPrefab;

    public void OnHit()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, duration);
        Destroy(gameObject);
    }
}
