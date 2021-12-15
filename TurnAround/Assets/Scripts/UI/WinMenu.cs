using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    private SceneLoader m_sceneLoader;
    private AudioManager m_audioManager;

    private void Start() {
        m_sceneLoader = FindObjectOfType<SceneLoader>();
        m_sceneLoader.SetActivePanels(false);

        m_audioManager = FindObjectOfType<AudioManager>();
        m_audioManager.Stop("BGM");
        m_audioManager.Play("Victory");
    }

    public void goToMenu() {
        m_sceneLoader.SetActivePanels(true);
        m_sceneLoader.LoadScene(0);
        m_audioManager.Stop("Victory");
        m_audioManager.Play("BGM");
    }

    public void quit() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
