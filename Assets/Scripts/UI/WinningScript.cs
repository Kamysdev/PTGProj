using UnityEngine;

public class WinningScript : MonoBehaviour
{
    [SerializeField] public GameObject panel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1f; // Resume the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
