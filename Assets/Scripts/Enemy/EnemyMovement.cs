﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        GameManager.instance.RadarDisplay.AddBlip(transform);
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
