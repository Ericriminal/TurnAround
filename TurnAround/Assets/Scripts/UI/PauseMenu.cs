using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MainMenu
{
    [SerializeField] private GameObject m_leaveMenu;
    [SerializeField] private GameObject m_panel;

    private bool m_inPauseMenu = false;

    private void Update() {
        if (Input.GetKeyDown("escape")) {
            if (!m_inPauseMenu) {
                pause();
            } else {
                resume();
            }
        }
    }

    public bool isInPauseMenu() {
        return m_inPauseMenu;
    }

    private void pause() {
        Time.timeScale = 0f;
        m_panel.SetActive(true);
        m_inPauseMenu = true;
    }

    public void resume() {
        closeSettingsMenu();
        closeLeaveMenu();
        Time.timeScale = 1f;
        m_panel.SetActive(false);
        m_inPauseMenu = false;
    }

    public void openLeaveMenu() {
        m_mainMenu.SetActive(false);
        m_leaveMenu.SetActive(true);
    }

    public void closeLeaveMenu() {
        m_mainMenu.SetActive(true);
        m_leaveMenu.SetActive(false);
    }

    public void goToMainMenu() {
        m_sceneLoader.LoadScene(0);
        resume();
    }
}
