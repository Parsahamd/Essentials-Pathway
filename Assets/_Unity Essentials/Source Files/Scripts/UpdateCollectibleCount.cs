using UnityEngine;
using TMPro;

public class UpdateCollectibleCount : MonoBehaviour
{
    public GameObject confettiPrefab;  // Assign the prefab here
    private TextMeshProUGUI collectibleText;
    private bool celebrationTriggered = false;

    void Start()
    {
        collectibleText = GetComponent<TextMeshProUGUI>();
        if (collectibleText == null)
        {
            Debug.LogError("UpdateCollectibleCount requires a TextMeshProUGUI component.");
            return;
        }
        UpdateCollectibleDisplay();
    }

    void Update()
    {
        UpdateCollectibleDisplay();
    }

    private void UpdateCollectibleDisplay()
    {
        int totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        collectibleText.text = $"Collectibles remaining: {totalCollectibles}";

        if (totalCollectibles == 0 && !celebrationTriggered)
        {
            celebrationTriggered = true;
            TriggerConfetti();
        }
    }

    private void TriggerConfetti()
    {
        if (confettiPrefab != null)
        {
            // Instantiate at player position or any position you want
            Instantiate(confettiPrefab, Vector3.zero, Quaternion.identity);
            Debug.Log("🎉 Confetti instantiated!");
        }
        else
        {
            Debug.LogWarning("Confetti prefab is not assigned.");
        }
    }
}