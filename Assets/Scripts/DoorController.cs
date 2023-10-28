using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimator;

    private void Start()
    {
        doorAnimator = GetComponent<Animator>();
        if (doorAnimator == null)
        {
            Debug.LogError("Animator component not found on Door object!");
        }
    }

    public void OpenDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }
    }
}
