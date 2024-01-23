using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneToLoad;


    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
