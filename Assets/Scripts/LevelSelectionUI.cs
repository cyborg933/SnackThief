using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Build index of the currently-loaded scene.
    private int currentScene = 0;

    // Current scene's level view camera, if any (assigned in Inspector).
    public GameObject levelViewCamera;

    // Current ongoing scene loading operation, if any.
    private AsyncOperation currentLoadOperation;

    // Method to play the current level.
    private void PlayCurrentLevel()
    {
        // Check if the level view camera is assigned and deactivate it.
        if (levelViewCamera != null)
        {
            levelViewCamera.SetActive(false);
        }
        else
        {
            Debug.LogError("Level View Camera is not assigned!");
        }

        // Try to find the Player GameObject.
        var playerGobj = GameObject.Find("Player");

        // Throw an error if we couldn't find it.
        if (playerGobj == null)
        {
            Debug.LogError("Couldn't find a Player in the level!");
        }
        else
        {
            // Get the Player script attached and enable it.
            var playerScript = playerGobj.GetComponent<Player>();
            playerScript.enabled = true;

            // Through the player script, access the camera GameObject and activate it.
            playerScript.cam.SetActive(true);

            // Destroy self; we'll come back when the main scene is loaded again.
            Destroy(this.gameObject);
        }
    }

    // Unity events:
    void Start()
    {
        // Make sure this object persists when the scene changes.
        DontDestroyOnLoad(gameObject);
    }

    void OnGUI()
    {
        GUILayout.Label("OBSTACLE COURSE");

        // If this isn't the main menu:
        if (currentScene != 0)
        {
            GUILayout.Label("Currently viewing Level " + currentScene);

            // Show a PLAY button.
            if (GUILayout.Button("PLAY"))
            {
                // If the button is clicked, start playing the level.
                PlayCurrentLevel();
            }
        }
        else // If this is the main menu
        {
            GUILayout.Label("Select a level to preview it.");
        }

        // Starting at scene build index 1, loop through the remaining scene indexes.
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            // Show a button with text "Level [level number]".
            if (GUILayout.Button("Level " + i))
            {
                // If that button is pressed, and we aren't already waiting for a scene to load:
                if (currentLoadOperation == null)
                {
                    // Start loading the level asynchronously.
                    currentLoadOperation = SceneManager.LoadSceneAsync(i);

                    // Set the current scene.
                    currentScene = i;
                }
            }
        }
    }
}
