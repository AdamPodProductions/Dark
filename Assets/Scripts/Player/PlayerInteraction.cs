using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform rayPoint;

    private TutorialText tutorialText;
    private Gas gas;

    private void Start()
    {
        tutorialText = FindObjectOfType<TutorialText>();
        gas = FindObjectOfType<Gas>();
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
                    gas.ActivateGas();
                }
            }
            else if (hit.transform.CompareTag("Exit"))
            {
                if (gas.IsActivated)
                {
                    tutorialText.SetText("Click to exit the room");

                    if (Input.GetMouseButtonDown(0))
                    {
                        FindObjectOfType<Exit>().ExitRoom();
                    }
                }
                else
                {
                    tutorialText.SetText("Activate gas before exiting room");
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
