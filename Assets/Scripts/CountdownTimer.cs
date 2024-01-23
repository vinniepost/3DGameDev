using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Text countdownText;
    private float countdownTime = 60f; // Initial time in seconds

    void Start()
    {
        // Ensure that the Text component is assigned
        if (countdownText == null)
        {
            Debug.LogError("Countdown Text not assigned properly!");
            return;
        }

        // Initialize the countdown text
        UpdateCountdownText();
    }

    void Update()
    {
        // Update the countdown timer
        countdownTime -= Time.deltaTime;

        // Clamp the countdown time to prevent negative values
        countdownTime = Mathf.Clamp(countdownTime, 0f, Mathf.Infinity);

        // Update the countdown text
        UpdateCountdownText();

        // Check if the countdown has reached zero
        if (countdownTime <= 0f)
        {
            // Go too endscreen

            // Perform actions when the countdown reaches zero (e.g., end the game)
            Debug.Log("Countdown reached zero. Game over!");
        }
    }

    void UpdateCountdownText()
    {
        // Convert the countdown time to minutes and seconds
        int minutes = Mathf.FloorToInt(countdownTime / 60f);
        int seconds = Mathf.FloorToInt(countdownTime % 60f);

        // Update the countdown text with the formatted time
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Call this method when a collectible is picked up to add 10 seconds
    public void AddTimeOnPickup()
    {
        countdownTime += 10f;

        // You may want to adjust this based on your game's design
        // For example, you might want to limit the maximum time.
    }
}
