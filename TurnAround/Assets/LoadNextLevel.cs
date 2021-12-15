using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //So you can use SceneManager

public class LoadNextLevel : MonoBehaviour
{
    // Start is called before the first frame update

    public string nextLevelName;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            SceneManager.LoadScene(nextLevelName);

        }  
    }
}
