using UnityEngine;

public class CollectableBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider c)
    {
        // Ensure the object has a Rigidbody attached
        if(c.attachedRigidbody != null)
        {
            BallCollector bc = c.attachedRigidbody.gameObject.GetComponent<BallCollector>();
            if(bc != null) // Check if the object has a BallCollector component
            {
                bc.ReceiveBall();

                // Trigger the event
                EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.position); // Placeholder, replace with actual event

                // Destroy the collectable ball
                Destroy(this.gameObject);
            }
        }
    }
}
