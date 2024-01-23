using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text pickupsText;

    private void Start()
    {
        // Ensure that you have a reference to the Text component in the Unity Editor.
        if (pickupsText == null)
        {
            Debug.LogError("Pickups Text not assigned properly!");
            return;
        }

        // Retrieve the stored pickups count from PlayerPrefs
        int pickupsCount = PlayerPrefs.GetInt("PickupsCollected", 0);

        // Initialize the HUD with the stored pickups count.
        UpdatePickupsUI(pickupsCount);
    }

    public void UpdatePickupsUI(int pickupsCount)
    {
        // Update the pickups text with the current pickups count.
        pickupsText.text = "Pickups: " + pickupsCount;
    }
}
