using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject blipPrefab;
    [SerializeField]
    private GameObject wallBlipPrefab;

    public Vector2 mapLimits;

    private Dictionary<Transform, Image> blipsOnDisplay = new Dictionary<Transform, Image>();

    private Transform player;

    [SerializeField]
    private Transform locationMarker;
    public GameObject LocationMarker { get { return locationMarker.gameObject; } }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        AddWalls();
    }

    private void Update()
    {
        ManageBlips();
        SetTrackLocation();
    }

    #region Manage blips
    private void SetBlipLocation(KeyValuePair<Transform, Image> blip)
    {
        blip.Value.transform.localPosition = new Vector2(blip.Key.position.x / mapLimits.x, blip.Key.position.z / mapLimits.y) * 350f;
    }

    private void ManageBlips()
    {
        foreach (KeyValuePair<Transform, Image> blip in blipsOnDisplay)
        {
            SetBlipLocation(blip);
        }
    }
    #endregion

    private void SetTrackLocation()
    {
        locationMarker.transform.position = player.position;
    }

    #region Add blips
    private void AddWalls()
    {
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag("Wall"))
        {
            AddWall(wall.transform);
        }
    }

    private void AddWall(Transform newWall)
    {
        Transform newWallDisplay = Instantiate(wallBlipPrefab, transform).transform;
        newWallDisplay.localPosition = new Vector2(newWall.position.x / mapLimits.x, newWall.position.z / mapLimits.y) * 350f;
        newWallDisplay.localScale = new Vector2(newWall.localScale.x / mapLimits.x, newWall.localScale.z / mapLimits.y) * 350f;
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

    public void AddStaticBlip(Vector3 newBlipPosition)
    {
        Image newBlipDisplay = Instantiate(blipPrefab, transform).GetComponent<Image>();
        newBlipDisplay.transform.localPosition = new Vector2(newBlipPosition.x / mapLimits.x, newBlipPosition.z / mapLimits.y) * 350f;
    }

    public void AddStaticBlip(Vector3 newBlipPosition, Color color)
    {
        Image newBlipDisplay = Instantiate(blipPrefab, transform).GetComponent<Image>();
        newBlipDisplay.color = color;
        newBlipDisplay.transform.localPosition = new Vector2(newBlipPosition.x / mapLimits.x, newBlipPosition.z / mapLimits.y) * 350f;
    }
    #endregion
}
