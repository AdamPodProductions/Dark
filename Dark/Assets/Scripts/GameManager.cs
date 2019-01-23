using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private RadarDisplay radarDisplay;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            radarDisplay.gameObject.SetActive(!radarDisplay.gameObject.activeInHierarchy);
            radarDisplay.LocationMarker.SetActive(true);
        }
    }
}
