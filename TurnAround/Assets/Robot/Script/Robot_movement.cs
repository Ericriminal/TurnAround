using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_movement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float moveSpeed;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        position = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTowardsTarget(position);
    }

    void MoveTowardsTarget(Vector3 position)
    {
        float offsetx = position.x - transform.position.x;
        float offsetz = position.z - transform.position.z;
        float velocityx = 0;
        float velocityz = 0;
    
        Debug.Log( " x = " + offsetx);
        Debug.Log(" y =" + offsetz);
        if (offsetx > 1 || offsetx < -1) {
            if (offsetx > 0)
                velocityx =  moveSpeed;
            else if (offsetx < 0)
                velocityx = (moveSpeed * -1);
        }
        else
            velocityx = 0;

        if (offsetz > 1 || offsetz < -1) {
            if (offsetz > 0)
                velocityz =  moveSpeed;
            else if (offsetz < 0)
                velocityz = (moveSpeed * -1);
        }
        else
            velocityz = 0;
        
        _rigidbody.velocity = new Vector3 (velocityx, _rigidbody.velocity.y, velocityz);
    }

    public void ActualizeTargetPosition(Vector3 NewTarget)
    {
        position = NewTarget;
    }
}
