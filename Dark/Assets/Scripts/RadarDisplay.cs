using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarDisplay : MonoBehaviour
{
    public GameObject blipPrefab;
    public Vector2 mapLimits;

    private Dictionary<Transform, Transform> blipsOnDisplay = new Dictionary<Transform, Transform>();

    private Transform player;
    [SerializeField]
    private Transform locationMarker;
    public GameObject LocationMarker { get { return locationMarker.gameObject; } }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        ManageBlips();
        SetTrackLocation();
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

    private void SetTrackLocation()
    {
        locationMarker.transform.position = player.position;
    }

    public void AddBlip(Transform newBlipTransform)
    {
        Transform newBlipDisplay = Instantiate(blipPrefab, transform).transform;
        blipsOnDisplay.Add(newBlipTransform, newBlipDisplay);
    }
}
