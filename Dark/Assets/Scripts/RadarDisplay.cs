using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarDisplay : MonoBehaviour
{
    public GameObject blipPrefab;
    public Vector2 mapLimits;

    private Dictionary<Transform, Transform> blipsOnDisplay = new Dictionary<Transform, Transform>();

    private void Update()
    {
        ManageBlips();
    }

    private void SetBlipLocation(KeyValuePair<Transform, Transform> blip)
    {
        blip.Value.localPosition = new Vector2(blip.Key.position.x / mapLimits.x, blip.Key.position.z / mapLimits.y) * 350f;
    }

    private void ManageBlips()
    {
        foreach (KeyValuePair<Transform, Transform> blip in blipsOnDisplay)
        {
            SetBlipLocation(blip);
        }
    }

    public void AddBlip(Transform newBlipTransform)
    {
        Transform newBlipDisplay = Instantiate(blipPrefab, transform).transform;
        blipsOnDisplay.Add(newBlipTransform, newBlipDisplay);
    }
}
