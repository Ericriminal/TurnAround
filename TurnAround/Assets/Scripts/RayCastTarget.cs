using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTarget : MonoBehaviour
{
    public Robot_movement RobotScript;
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            Debug.Log(hit.collider.name);
            if (hit.collider.name == "Robot") {
                if (Input.GetKeyDown(KeyCode.E)) {
                    RobotScript.ActualizeTargetPosition(transform.position);
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
