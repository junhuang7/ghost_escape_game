using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollController : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    public AudioClip babyCry;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        // Create an AudioSource component if it doesn't exist.
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("UserIsHere", true);
            
            if (babyCry != null)
            {
                audioSource.PlayOneShot(babyCry);
            }
            else
            {
                Debug.LogError("babyCry AudioClip is not assigned.");
            }
        }
    }
}


