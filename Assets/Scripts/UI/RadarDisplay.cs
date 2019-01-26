using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarDisplay : MonoBehaviour
{
    public GameObject blipPrefab;
    public Vector2 mapLimits;

    private Dictionary<Transform, Image> blipsOnDisplay = new Dictionary<Transform, Image>();

    private Transform player;

    [SerializeField]
    private Transform locationMarker;
    public GameObject LocationMarker { get { return locationMarker.gameObject; } }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        ManageStaticBlips();
    }

    private void Update()
    {
        ManageBlips();
        SetTrackLocation();
    }

    private void SetBlipLocation(KeyValuePair<Transform, Image> blip)
    {
        blip.Value.transform.localPosition = new Vector2(blip.Key.position.x / mapLimits.x, blip.Key.position.z / mapLimits.y) * 350f;
    }

    private void ManageBlips()
    {
        foreach (KeyValuePair<Transform, Image> blip in blipsOnDisplay)
        {
            if (!blip.Key.gameObject.isStatic)
                SetBlipLocation(blip);
        }
    }

    private void ManageStaticBlips()
    {
        foreach (KeyValuePair<Transform, Image> blip in blipsOnDisplay)
        {
            if (blip.Key.gameObject.isStatic)
                SetBlipLocation(blip);
        }
    }

    private void SetTrackLocation()
    {
        locationMarker.transform.position = player.position;
    }

    public void AddBlip(Transform newBlipTransform)
    {
        Image newBlipDisplay = Instantiate(blipPrefab, transform).GetComponent<Image>();
        blipsOnDisplay.Add(newBlipTransform, newBlipDisplay);
    }

    public void AddBlip(Transform newBlipTransform, Color color)
    {
        Image newBlipDisplay = Instantiate(blipPrefab, transform).GetComponent<Image>();
        newBlipDisplay.color = color;
        blipsOnDisplay.Add(newBlipTransform, newBlipDisplay);
    }
}
