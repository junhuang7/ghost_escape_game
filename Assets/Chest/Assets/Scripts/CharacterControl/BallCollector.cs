using UnityEngine;

public class BallCollector : MonoBehaviour
{
    public bool hasBall = false;

    public void ReceiveBall()
    {
        hasBall = true;
     }
}
