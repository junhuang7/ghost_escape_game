using UnityEngine;

public class VelocityReporter : MonoBehaviour 
{
    // The previous position of the object
    private Vector3 prevPos;  
    // The raw calculated velocity
    [SerializeField]
    private Vector3 rawVelocity;
    // The smoothed velocity
    [SerializeField]
    private Vector3 velocity; 
    // Smoothing factor for velocity computation
    public float smoothingDuration = 0.5f;
    // Reference velocity for smoothing function  
    private Vector3 smoothingParamVel; 

    void Start() 
    {
        prevPos = this.transform.position;
    }

    void Update() 
    {
        // Ensure we don't divide by zero
        if(!Mathf.Approximately(Time.deltaTime, 0f))
        {
            // Compute the raw velocity based on the change in position over time
            rawVelocity = (this.transform.position - prevPos) / Time.deltaTime;
            
            // Smoothly interpolate between the current velocity and raw velocity
            velocity = Vector3.SmoothDamp(velocity, rawVelocity, ref smoothingParamVel, smoothingDuration);
        } 
        else 
        {
            rawVelocity = Vector3.zero;
            velocity = Vector3.zero;
        }
        
        prevPos = this.transform.position;
    }

    public Vector3 GetVelocity()
    {
        return velocity;
    }

    public Vector3 GetRawVelocity()
    {
        return rawVelocity;
    }
}
