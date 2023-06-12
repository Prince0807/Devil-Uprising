using UnityEngine;

public class ProximitySensor : Sensor_Base
{
    [SerializeField] private float detectionRange = 5f;

    private void Update()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) < detectionRange)
            isDetected = true;
        else
            isDetected = false;
    }
}
