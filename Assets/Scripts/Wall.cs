using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private RadarDisplay radarDisplay;

    private void Start()
    {
        radarDisplay.AddWall(transform);
    }
}
