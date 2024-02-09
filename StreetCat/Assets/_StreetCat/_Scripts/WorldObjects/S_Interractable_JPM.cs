using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Interractable_JPM : MonoBehaviour
{
    [Scene]
    [SerializeField]
    private string sceneName;
    private void Interractable()
    {
        SceneManager.LoadScene(sceneName);
    }
}
