using System.Collections;
using UnityEngine;

public class DoorOpenController2 : MonoBehaviour
{
    public float openDistance = 15.0f; // Distance at which the door will open
    public GameObject Ball1; // Reference to the Ball1 object

    private bool isDoorOpen = false;
    private Animation doorAnimation;
    private Transform Ball1Transform;

    private void Start()
    {
        // Get the Animation component attached to this GameObject
        doorAnimation = GetComponent<Animation>();
        // Check if the Animation component or the Animation Clip is missing
        if (doorAnimation == null)
        {
            Debug.LogError("Animation component is missing!");
        }
        else if (doorAnimation.GetClip("Door2_Open") == null)
        {
            Debug.LogError("Animation clip 'Door2_Open' is missing!");
        }

        if (Ball1 != null)
        {
            // Get the Transform component of the Ball1
            Ball1Transform = Ball1.transform;
        }
        else
        {
            Debug.LogError("Ball1 reference is missing!");
        }
    }

    private void Update()
    {
        // Check if Ball1 is close enough to the door
        if (Ball1Transform != null && Vector3.Distance(transform.position, Ball1Transform.position) <= openDistance)
        {
            // Open the door if it's not already open
            if (!isDoorOpen)
            {
                ToggleDoor();
            }
        }
        else
        {
            // Optional: Close the door if Ball1 is not close enough
            if (isDoorOpen)
            {
                CloseDoor();
            }
        }
    }

    public void ToggleDoor()
    {
        // Play the "Door2_Open" animation
        if (doorAnimation != null)
        {
            doorAnimation.Play("Door2_Open");
            isDoorOpen = true;
        }
    }

    private void CloseDoor()
    {
        // Optional: Play the "Door_Close" animation
        if (doorAnimation != null && doorAnimation.GetClip("Door_Close") != null)
        {
            doorAnimation.Play("Door_Close");
            isDoorOpen = false;
        }
    }
}
