using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFlicker : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        text = GetComponent<Text>();
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        yield return new WaitForSeconds(Random.Range(0.25f, 2f));
        text.enabled = false;

        yield return new WaitForSeconds(Random.Range(0.25f, 2f));
        text.enabled = true;

        StartCoroutine(Flicker());
    }
}
