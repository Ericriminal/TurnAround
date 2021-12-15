using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    [SerializeField] private GameObject leftPanel;
    [SerializeField] private GameObject rightPanel;

    private void Awake() {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void SetActivePanels(bool active) {
        leftPanel.SetActive(active);
        rightPanel.SetActive(active);
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadScene1(sceneIndex));
    }

    private IEnumerator LoadScene1(int sceneIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }
}
