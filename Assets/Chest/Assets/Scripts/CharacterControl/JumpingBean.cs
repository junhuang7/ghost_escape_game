using UnityEngine;
using System.Collections;

public class JumpingBean : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded;

    // Variables for jump timing
    private float nextJumpTime;
    private float jumpFrequencyMin = 2.0f; // Minimum time between jumps (in seconds)
    private float jumpFrequencyMax = 5.0f; // Maximum time between jumps (in seconds)

    // Variables for jump force
    private float jumpForceMin = 5.0f; // Minimum force
    private float jumpForceMax = 15.0f; // Maximum force

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ScheduleNextJump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }

    private void ScheduleNextJump()
    {
        nextJumpTime = Time.time + Random.Range(jumpFrequencyMin, jumpFrequencyMax);
    }

    private void FixedUpdate()
    {
        if (isGrounded && Time.time >= nextJumpTime)
        {
            // Calculate jump force
            Vector3 force = new Vector3(Random.Range(-1f, 1f), 1, Random.Range(-1f, 1f)) * Random.Range(jumpForceMin, jumpForceMax);
            
            // Apply jump force
            rb.AddForce(force, ForceMode.Impulse);
            
            // Schedule the next jump
            ScheduleNextJump();
        }
    }
}
