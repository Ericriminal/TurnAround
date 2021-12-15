using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTrigger : MonoBehaviour
{
    public bool win = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Robot")
        {
            ParticleSystem pc = gameObject.GetComponent<ParticleSystem>();
            win = true;
            var main = pc.main;
            main.startColor = new Color(56, 255, 0);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
