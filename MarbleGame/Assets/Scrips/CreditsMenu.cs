//Final Project --- CreditsMenu.cs by Sebastian Ulloa


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{
    public void OnMainMenuClicked()
    {
        SceneManager.LoadSceneAsync("Title Screen");
    }

    public void OnExitGameClicked()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
