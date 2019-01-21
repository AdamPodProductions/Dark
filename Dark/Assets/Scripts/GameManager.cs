using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject radarDisplay;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        radarDisplay = FindObjectOfType<RadarDisplay>().gameObject;
        radarDisplay.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            radarDisplay.SetActive(!radarDisplay.activeInHierarchy);
        }
    }
}
