using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] protected GameObject m_mainMenu;
    [SerializeField] protected GameObject m_settingsMenu;
    protected SceneLoader m_sceneLoader;

    private void Awake() {
        m_sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void play() {
        m_sceneLoader.LoadScene(1);
    }

    public void openSettingsMenu() {
        m_mainMenu.SetActive(false);
        m_settingsMenu.SetActive(true);
    }

    public void closeSettingsMenu() {
        m_mainMenu.SetActive(true);
        m_settingsMenu.SetActive(false);
    }

    public void quit() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
