using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    private bool isActivated = false;
    public bool IsActivated { get { return isActivated; } }

    [SerializeField]
    private GameObject gasTimer;

    [SerializeField]
    private RadarDisplay radarDisplay;

    private void Start()
    {
        radarDisplay.AddBlip(transform, Color.red);
    }

    private IEnumerator GasTimer()
    {
        yield return new WaitForSeconds(10);
        gasTimer.SetActive(false);

        FindObjectOfType<SceneChanger>().ChangeScene("GameOver", false);
    }

    public void ActivateGas()
    {
        if (!isActivated)
        {
            isActivated = true;
            gasTimer.SetActive(true);
            StartCoroutine(GasTimer());
        }
    }
}
