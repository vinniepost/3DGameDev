using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneToLoad;
    public int minimum;

    public AudioClip soundClip; // Reference to your audio clip
    private AudioSource audioSource;


    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Ensure that an audio clip is assigned
        if (soundClip == null)
        {
            Debug.LogError("Audio clip not assigned!");
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            int energy = PlayerPrefs.GetInt("PickupsCollected");
            if (energy > minimum)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                PlaySound();
            }
        }
    }

    void PlaySound()
    {
        if (audioSource != null && soundClip != null)
        {
            // Assign the audio clip to the AudioSource
            audioSource.clip = soundClip;

            // Play the audio
            audioSource.Play();
        }
    }

}
