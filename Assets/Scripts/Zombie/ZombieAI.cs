using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Sensor_Base[] sensorList;

    [Header("Zombie Stats")]
    public float walkSpeed = 1f;
    public float runSpeed = 2f;

    [SerializeField] private ZombieState state = ZombieState.IDLE;
    private bool isPlayerDetected;
    private Vector3 lastSeenLocation;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<InputManager>().transform;

        sensorList = GetComponents<Sensor_Base>();
    }

    private void Update()
    {
        switch (state)
        {
            case ZombieState.IDLE:
                break;

            case ZombieState.PATROL:
                break;

            case ZombieState.INVESTIGATE:
                break;
            
            case ZombieState.RUN:
                break;
            
            case ZombieState.ATTACK:
                break;
            
            case ZombieState.DEAD:
                break;
        }

        foreach (var sensor in sensorList)
        {
            isPlayerDetected = isPlayerDetected || sensor.isDetected;
        }
    }

    IEnumerator Patrol()
    {
        yield return new WaitForSeconds(5f);
    }

    IEnumerator Investigate()
    {
        yield return new WaitForSeconds(5f);
    }

    IEnumerator Run()
    {
        yield return new WaitForSeconds(5f);
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(5f);
    }


}

public enum ZombieState
{
    IDLE,
    PATROL,
    INVESTIGATE,
    RUN,
    ATTACK,
    DEAD
}
