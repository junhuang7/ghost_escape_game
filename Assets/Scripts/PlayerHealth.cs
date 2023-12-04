using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public Text healthText; // UI Text for displaying health
    public Text deathMessageText; // UI Text for displaying death message
    public Text hintMessageText; // UI Text for displaying the hint
    public Camera deathCamera; // Camera to activate upon death
    public AudioClip damageSound; // Sound to play when taking damage
    public GameObject ghostObject; // Reference to the ghost GameObject

    private AudioSource audioSource;
    private bool hintDisplayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        UpdateHealthDisplay();
        if (deathMessageText != null)
            deathMessageText.gameObject.SetActive(false);
        if (hintMessageText != null)
            hintMessageText.gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        PlayDamageSound();
        UpdateHealthDisplay();

        if (health <= 0)
        {
            StartCoroutine(HandleDeath());
        }
        else if (health <= 50 && !hintDisplayed)
        {
            StartCoroutine(DisplayHint());
        }
    }

    void UpdateHealthDisplay()
    {
        if (healthText != null)
            healthText.text = "Health: " + health;
    }

    IEnumerator HandleDeath()
    {
        if (deathMessageText != null)
        {
            deathMessageText.gameObject.SetActive(true);
            deathMessageText.text = "Player is Dead!";
        }

        // Deactivate the ghost object 
        if (ghostObject != null)
        {
            ghostObject.SetActive(false);
        }

        // Activate the death camera
        if (deathCamera != null)
        {
            deathCamera.gameObject.SetActive(true);
        }

        // Deactivate the main camera
        if (Camera.main != null)
        {
            Camera.main.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void PlayDamageSound()
    {
        if (damageSound != null)
            audioSource.PlayOneShot(damageSound);
    }

    IEnumerator DisplayHint()
    {
        hintDisplayed = true;
        if (hintMessageText != null)
        {
            hintMessageText.gameObject.SetActive(true);
            hintMessageText.text = "Press E to scare it away!";
        }
        yield return new WaitForSeconds(3);
        if (hintMessageText != null)
        {
            hintMessageText.gameObject.SetActive(false);
        }
    }
}
