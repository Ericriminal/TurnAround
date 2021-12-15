using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTarget : MonoBehaviour
{
    public Robot_movement RobotScript;
    public LayerMask layerMask;
    public GameObject Canvas;
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Canvas.SetActive(true);
            if (hit.collider.tag == "Robot") {
                if (Input.GetKeyDown(KeyCode.E)) {
                    hit.transform.gameObject.GetComponent<Robot_movement>().ActualizeTargetPosition(transform.position);
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Canvas.SetActive(false);
        }
    }
}
