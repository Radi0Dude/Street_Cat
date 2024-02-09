using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_MenuButton_JPM : MonoBehaviour
{
    // Start is called before the first frame update
   
    public void Button(string buildIndexReference)
    {
        SceneManager.LoadScene(buildIndexReference);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
