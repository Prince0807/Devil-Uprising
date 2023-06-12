using UnityEngine;

public class VisionSensor : Sensor_Base
{
    [SerializeField] private float detectionRange = 20f;
    [SerializeField] private float detectionAngle = 90f;

    private void Update()
    {
        // Calculate the direction from AI Agent to the player
        Vector3 direction = playerTransform.position - transform.position;
        RaycastHit raycastHitInfo;
        
        // hit Raycast towards player and check if it is in range.
        if (Physics.Raycast(transform.position, direction, out raycastHitInfo, detectionRange))
        {
            // If raycast hits player and the absolute angle between player and AI agent is within detection angle range, the player is detected.
            if (raycastHitInfo.collider.tag == "Player" && (Mathf.Abs(Vector3.Angle(transform.forward, direction)) <= detectionAngle))
            {
                isDetected = true;
                return;
            }
        }

        isDetected = false;
    }
}
