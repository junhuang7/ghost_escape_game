using UnityEngine;
using TMPro;

public class CelebrationController : MonoBehaviour
{
    public ParticleSystem confettiEffect; // Particle system for confetti
    public TextMeshProUGUI congratulatoryText; // TextMeshPro UI element for the message

    void Start()
    {
        // Make the TextMeshPro text invisible at the start
        if (congratulatoryText != null)
        {
            congratulatoryText.alpha = 0;
        }
    }

    public void Celebrate()
    {
        // Trigger the confetti effect
        confettiEffect.Play();

        // Display the congratulatory message
        if (congratulatoryText != null)
        {
            congratulatoryText.text = "Congratulations, you opened all 3 doors and now you escaped!";
            congratulatoryText.fontSize = 36; // Increase font size
            congratulatoryText.color = Color.green; // Change text color
            congratulatoryText.alpha = 1; // Make the text visible
        }
    }
}
