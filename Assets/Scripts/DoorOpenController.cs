using System.Collections;
using UnityEngine;

public class DoorOpenController : MonoBehaviour
{
    private bool isDoorOpen = false;
    private Animation doorAnimation;

    private void Start()
    {
        // Get the Animation component attached to this GameObject
        doorAnimation = GetComponent<Animation>();
        // Check if the Animation component or the Animation Clip is missing
        if (doorAnimation == null)
        {
            Debug.LogError("Animation component is missing!");
        }
        else if (doorAnimation.GetClip("Door_Open") == null)
        {
            Debug.LogError("Animation clip 'Door_Open' is missing!");
        }
    }

    public void ToggleDoor()
    {
        if (!isDoorOpen)
        {
            // Play the "Door_Open" animation
            if (doorAnimation != null)
            {
                doorAnimation.Play("Door_Open");
            }
            isDoorOpen = true;
        }
    }
}
