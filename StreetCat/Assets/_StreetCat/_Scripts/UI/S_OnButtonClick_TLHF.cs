using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_OnButtonClick_TLHF : MonoBehaviour
{
    [Scene]
    [SerializeField]
    string sceneName;
    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
