using TMPro;
using UnityEngine;

public class TargetCounterScript : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;
    private int targetCount = 0;

    private void Start()
    {
        UpdateCounterText();
    }

    public void IncrementCounter()
    {
        targetCount++;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        counterText.text = "Targets Hit: " + targetCount;
    }
}
