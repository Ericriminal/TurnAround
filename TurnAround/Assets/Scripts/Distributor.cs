using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distributor : MonoBehaviour
{
    // Start is called before the first frame update

    public InventoryManager inv;
    public GameObject robot;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (inv.HasObject("Key"))
                robot.SetActive(true);
        }
    }
}
