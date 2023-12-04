using UnityEngine;
using TMPro; // Required for TextMeshPro elements

public class AIPuzzleController : MonoBehaviour
{
    public Transform pointA; // Position near the red sphere
    public Transform pointB; // Position near the blue sphere
    public GameObject heroPlayer; // The HEROPLAYER GameObject
    public AnimationClip doorOpenClip; // Reference to the door open animation clip
    public CelebrationController celebrationController; // Reference to the CelebrationController
    private Animation doorAnimation; // Animation component on the door
    public TextMeshProUGUI congratulatoryText; // TextMeshPro UI element for the message

    public float speed = 0.5f; // AI cube's movement speed
    public float activationProximity = 1.0f; // Proximity required for activation

    private bool redSphereActivated = false;
    private bool blueSphereActivated = false;
    private bool movingToB = true;
    private bool doorOpened = false;

    private enum AIState { RedSphereChasing, BlueSphereChasing }
    private AIState currentState;

    void Start()
    {
        doorAnimation = GameObject.Find("Door3").GetComponent<Animation>();
        currentState = AIState.RedSphereChasing; // Start with chasing the red sphere
    }

    void Update()
    {
        MoveAI();
        CheckActivation(ref redSphereActivated, "RedSphere");
        CheckActivation(ref blueSphereActivated, "BlueSphere");

        if (redSphereActivated && blueSphereActivated && !doorOpened)
        {
            doorAnimation.clip = doorOpenClip;
            doorAnimation.Play();
            doorOpened = true; // Ensure the animation is played only once
            // Display the congratulatory message using TextMeshPro
            congratulatoryText.text = "Congratulations, you opened all 3 doors and now you escaped!";
            celebrationController.Celebrate();
        }

        
    }

    void MoveAI()
    {
        Transform target;
        if (movingToB)
        {
            target = pointB;
            currentState = AIState.BlueSphereChasing; // Update state
        }
        else
        {
            target = pointA;
            currentState = AIState.RedSphereChasing; // Update state
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            movingToB = !movingToB;
        }

        // Optional: Log the current state for debugging
        // Debug.Log("Current AI State: " + currentState);
    }

    void CheckActivation(ref bool sphereActivated, string sphereName)
    {
        if (!sphereActivated)
        {
            GameObject sphere = GameObject.Find(sphereName);
            float distanceToCube = Vector3.Distance(transform.position, sphere.transform.position);
            float distanceToPlayer = Vector3.Distance(heroPlayer.transform.position, sphere.transform.position);

            if (distanceToCube <= activationProximity && distanceToPlayer <= activationProximity)
            {
                sphere.GetComponent<Renderer>().material.color = Color.green;
                sphereActivated = true;
            }
        }
    }
}
