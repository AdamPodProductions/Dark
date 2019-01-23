using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject loading;

    public void ChangeScene(int sceneIndex)
    {
        loading.SetActive(true);
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeScene(string sceneName)
    {
        loading.SetActive(true);
        SceneManager.LoadScene(sceneName);
    }
}
