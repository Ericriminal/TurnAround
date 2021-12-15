using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robot_movement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float moveSpeed;
    private Vector3 position;
    private NavMeshAgent agent;
    public Transform spawnpoint;
    public bool fall = false;
    public AudioClip Spawn;
    public AudioClip Order;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        position = transform.position;
        agent = gameObject.GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Spawn, 0.2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTowardsTarget(position);
    }

    void MoveTowardsTarget(Vector3 position)
    {
        if (fall == false)
            agent.destination = position; 
    }

    public void ActualizeTargetPosition(Vector3 NewTarget)
    {
        position = NewTarget;
        audioSource.PlayOneShot(Order);
    }
}
