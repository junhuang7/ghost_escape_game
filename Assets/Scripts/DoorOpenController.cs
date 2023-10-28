using UnityEngine;

public class DoorOpenController : MonoBehaviour
{
    public Animator doorAnimator; // Assign this in the inspector
    private bool isOpen = false;

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        doorAnimator.SetBool("isOpen", isOpen);
    }
}
