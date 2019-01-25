using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform rayPoint;

    private void Update()
    {
        CheckRaycast();
    }

    private void CheckRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(rayPoint.position, rayPoint.forward, out hit, 4.5f))
        {
            if (hit.transform.CompareTag("Gas"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    FindObjectOfType<Gas>().ActivateGas();
                }
            }
        }
    }
}
