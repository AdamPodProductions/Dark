using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private RadarDisplay radarDisplay;
    public RadarDisplay RadarDisplay { get { return radarDisplay; } }

    private void OnEnable()
    {
        instance = this;
    }

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
