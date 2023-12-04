using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AIAgentChase3 : MonoBehaviour
{
    public Transform HEROPLAYER;
    public AudioClip chaseSound; 
    private AudioSource audioSource;
    private NavMeshAgent agent;
    private Animator anim;
    public float hitImpactForce = 5f;
    public float attackCooldown = 3f;
    private bool hasChaseStarted = false;
    private bool isAttacking = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Start the chase after a delay
        Invoke("StartChase", 35.0f);
    }

    private void Update()
    {
        if (hasChaseStarted && !isAttacking)
        {
            ChasePlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == HEROPLAYER && !isAttacking)
        {
            StartCoroutine(HandleAttack());
        }
    }

    IEnumerator HandleAttack()
    {
        isAttacking = true;
        PlayerHealth playerHealth = HEROPLAYER.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(10); // Assuming the player takes 10 damage
        }

    
        // Back off a little
        Vector3 backOffPosition = transform.position + (-transform.forward * hitImpactForce);
        agent.SetDestination(backOffPosition);
        yield return new WaitForSeconds(attackCooldown); // Wait before chasing again

        isAttacking = false;
    }

    void StartChase()
    {
        hasChaseStarted = true;
    }

    void ChasePlayer()
    {
        agent.SetDestination(HEROPLAYER.position);
        if (anim != null)
        {
            anim.SetFloat("vely", agent.velocity.magnitude / agent.speed);
        }
    }

    public void DisappearAfterSpell()
    {
        if (audioSource && chaseSound)
        {
            audioSource.PlayOneShot(chaseSound);
        }
        StartCoroutine(DeactivateAfterSound());
    }

    IEnumerator DeactivateAfterSound()
    {
        yield return new WaitForSeconds(chaseSound != null ? chaseSound.length : 1f);
        gameObject.SetActive(false);
    }
}
