using UnityEngine;

public class ShellEjectionScript : MonoBehaviour
{
    [SerializeField] private Transform ejectionPoint;
    [SerializeField] private GameObject shellPrefab;
    [SerializeField][Range(1, 100)] private float ejactionForce;
    [SerializeField][Range(1, 10)] private float duration; 

    public void EjectShell()
    {
        GameObject shell = Instantiate(shellPrefab, ejectionPoint.position, ejectionPoint.rotation);
        shell.GetComponent<Rigidbody>().AddForce(ejectionPoint.right * ejactionForce, ForceMode.Impulse);

        Destroy(shell, duration);
    }
}
