using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;
   // public Vector3 target;
    public Transform target;
    public Transform[] waypoints;
    public float moveSpeed;
    [SerializeField] float stoppingDist = 2f;
   private int waypointIndex;
    //public Transform waypoints;
    public int viewDist;
    public enum State
    {
        patrol,
        hunt,
        search,
        attack
    }
    public State stateIndex;
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();

    }


   public void FixedUpdate()
    {
        //agent.SetDestination(target.position);
        //agent.SetDestination(waypoints.position);
        if (stateIndex == State.patrol)
        {
            patrol();
        }
        RaycastHit hit;
        Physics.Raycast(transform.position, target.position-transform.position, out hit, viewDist);
        if (hit.collider.CompareTag("Player"))
        {
            stateIndex = State.hunt;
            agent.SetDestination(target.position);
        }
        else
        {
            stateIndex = State.patrol;
            agent.SetDestination(waypoints[waypointIndex].position);
        }
    }
    private void patrol()
    {
        float distToTarget = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (distToTarget <= stoppingDist)
        {
            waypointIndex = (waypointIndex + 1) %waypoints.Length;
        }
        //target = waypoints[waypointIndex].position;
        agent.SetDestination(waypoints[waypointIndex].position);
    }
    
}
