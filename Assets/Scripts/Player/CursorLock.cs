using UnityEngine;

public class CursorLock : MonoBehaviour
{
    [SerializeField] private bool isCursorLocked = true;
    
    void OnEscape()
    {
        isCursorLocked = !isCursorLocked;
        UpdateCursorLock();
    }

    void UpdateCursorLock()
    {
        if (isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Debug.Log("Cursor lock state changed: " + isCursorLocked);
    }
}
