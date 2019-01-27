using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public string nextLevel;

    [SerializeField]
    private RadarDisplay radarDisplay;

    private Gas gas;
    private SceneChanger sceneChanger;

    private void Start()
    {
        radarDisplay.AddStaticBlip(transform.position, Color.blue);

        gas = FindObjectOfType<Gas>();
        sceneChanger = FindObjectOfType<SceneChanger>();
    }

    public void ExitRoom()
    {
        if (gas.IsActivated)
        {
            sceneChanger.ChangeScene(nextLevel);
        }
    }
}
