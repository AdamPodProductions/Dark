using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private RadarDisplay radarDisplay;

    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        radarDisplay.AddBlip(transform, Color.red);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("LocationMarker"))
        {
            navMeshAgent.destination = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LocationMarker"))
        {
            navMeshAgent.destination = transform.position;
        }
    }
}
