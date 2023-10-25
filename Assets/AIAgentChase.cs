using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AIAgentChase : MonoBehaviour
{
    public Transform HEROPLAYER;
    public AudioClip chaseSound; 
    private AudioSource audioSource;
    private NavMeshAgent agent;
    private Animator anim;
    private VelocityReporter velocityReporter;
    private bool hasChaseStarted = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        velocityReporter = HEROPLAYER.GetComponent<VelocityReporter>();

        if (velocityReporter == null)
        {
            velocityReporter = HEROPLAYER.gameObject.AddComponent<VelocityReporter>();
        }

        // Start the chase after 10 seconds
        Invoke("StartChase", 10.0f);
    }

    private void Update()
    {
        if (hasChaseStarted)
        {
            ChasePlayer();
        }

        if (Vector3.Distance(transform.position, HEROPLAYER.position) <= agent.stoppingDistance)
        {
            // Once the agent reaches HEROPLAYER position, it will disappear
            DisappearAndPlaySound();
        }
    }

    void StartChase()
    {
        hasChaseStarted = true;
    }

    void ChasePlayer()
    {
        agent.SetDestination(HEROPLAYER.position);
        anim.SetFloat("vely", agent.velocity.magnitude / agent.speed);
    }

    void DisappearAndPlaySound()
    {
        audioSource.PlayOneShot(chaseSound); // Play the audio once the agent is close to the HEROPLAYER
        StartCoroutine(DeactivateAfterSound());
    }

    IEnumerator DeactivateAfterSound()
    {
        yield return new WaitForSeconds(chaseSound.length); // Wait for the duration of the audio clip
        gameObject.SetActive(false); // Make the agent disappear
    }
}
