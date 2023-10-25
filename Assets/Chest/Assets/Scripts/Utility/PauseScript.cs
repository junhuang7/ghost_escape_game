using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = true;  // Start with the game paused

    private void Start()
    {
        TogglePause(); // Pause the game at the start
    }

    private void Update()
    {
        // Check if the 'P' key has been released
        if (Input.GetKeyUp(KeyCode.P))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;  // Resume game
        }
        else
        {
            Time.timeScale = 0f;  // Pause game
        }

        isPaused = !isPaused;  // Toggle the pause state
    }
}
