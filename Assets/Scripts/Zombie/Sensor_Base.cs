using UnityEngine;

public class Sensor_Base : MonoBehaviour
{
    [HideInInspector] public bool isDetected = false;
    protected Transform playerTransform;

    private void Start()
    {
        playerTransform = GetComponent<ZombieAI>().player;
    }
}
