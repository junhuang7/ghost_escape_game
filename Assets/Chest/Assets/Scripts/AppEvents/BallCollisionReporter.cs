using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionReporter : MonoBehaviour
{
    void OnCollisionEnter(Collision c)
    {
        // We'll just use the first contact point for simplicity
        EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.contacts[0].point);
    }
}
