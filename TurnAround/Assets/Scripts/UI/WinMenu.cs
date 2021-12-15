using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    private SceneLoader m_sceneLoader;

    private void Awake() {
        m_sceneLoader = FindObjectOfType<SceneLoader>();
        m_sceneLoader.SetActivePanels(false);
    }

    public void goToMenu() {
        m_sceneLoader.SetActivePanels(true);
        m_sceneLoader.LoadScene(0);
    }

    public void quit() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
