using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTargetRobot : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject canvasRobot;
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            canvasRobot.SetActive(true);
            if (hit.collider.tag == "Robot") {
                if (Input.GetKeyDown(KeyCode.E)) {
                    hit.transform.gameObject.GetComponent<Robot_movement>().ActualizeTargetPosition(transform.position);
                }
            } else {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                canvasRobot.SetActive(false);
            }
        } else {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            canvasRobot.SetActive(false);
        }
    }
}
