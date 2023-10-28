using UnityEngine;

public class DoorOpenController : MonoBehaviour
{
    public CubeSequenceChecker cubeSequenceChecker;
    public DoorController doorScript; // Replace DoorScriptType with the actual type of your door's script
    
    private bool doorOpened = false;

    private void Update()
    {
        if (!doorOpened && cubeSequenceChecker.CheckSequence())
        {
            doorScript.OpenDoor();
            doorOpened = true;
        }
    }
}
