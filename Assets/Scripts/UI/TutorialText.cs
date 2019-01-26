using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    public bool Avaliable { get; private set; }

    [SerializeField]
    private Text text;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Avaliable = true;
            text.text = string.Empty;
        }
    }

    public void SetText(string setText)
    {
        if (Avaliable)
        {
            text.text = setText;
        }
    }
}
