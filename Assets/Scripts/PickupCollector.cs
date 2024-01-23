using UnityEngine;

public class PickupCollector : MonoBehaviour
{
    private int pickupsCollected = 0;
    public HUDController hudController;

    private void Start()
    {
        // Retrieve the stored pickups count from PlayerPrefs
        pickupsCollected = PlayerPrefs.GetInt("PickupsCollected", 0);

        // Make sure to assign the HUDController reference in the Unity Editor.
        if (hudController == null)
        {
            Debug.LogError("HUDController not assigned properly!");
        }
        else
        {
            // Initialize the HUD with the starting pickups count.
            hudController.UpdatePickupsUI(pickupsCollected);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            pickupsCollected = PlayerPrefs.GetInt("PickupsCollected", 0);

            pickupsCollected++;

            // Save the updated pickups count to PlayerPrefs
            PlayerPrefs.SetInt("PickupsCollected", pickupsCollected);

            hudController.UpdatePickupsUI(pickupsCollected);

            //countdownTimer.AddTimeOnPickup();
        }
    }
}
