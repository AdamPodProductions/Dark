using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform rayPoint;

    private TutorialText tutorialText;

    private void Start()
    {
        tutorialText = FindObjectOfType<TutorialText>();
    }

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
                tutorialText.SetText("Click to activate gas");

                if (Input.GetMouseButtonDown(0))
                {
                    FindObjectOfType<Gas>().ActivateGas();
                }
            }
            else
            {
                tutorialText.SetText(string.Empty);
            }
        }
        else
        {
            tutorialText.SetText(string.Empty);
        }
    }
}
