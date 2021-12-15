using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public RobotTrigger trig;
    public GameObject text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trig.win) {
            text.SetActive(false);
            gameObject.SetActive(false);
        }
        
    }
}
