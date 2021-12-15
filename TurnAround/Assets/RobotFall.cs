using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotFall : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.tag == "Robot") {
            other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            other.gameObject.GetComponent<Robot_movement>().fall = true;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
