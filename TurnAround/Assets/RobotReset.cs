using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotReset : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject Robot;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Robot") {
            Destroy(other.gameObject);
            Instantiate(Robot, Spawnpoint.position, Quaternion.identity);
        }
    }
}
