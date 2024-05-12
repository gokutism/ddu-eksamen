using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveeeee : MonoBehaviour//, IDamageable
{
    [Header("Navigation Settings")]
    NavMeshAgent agent;
    public Transform target;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] float stoppingDistance = 2f;
    public float viewDist = 20f;
    private Vector3 lastKnownPos = Vector3.zero;
    Animator animator;

    public enum State
    {
        patrol,
        hunt,
        search,
        attack,
        searching
    }
    [Header("State Machine Settings")]
    public State currentState;

    [Header("State Machine setting")]
    public GameObject bullet;
    public float rps = 1 / 2f;
    public float bulletspeed = 10f;
    public Transform bulletspawnpos;
    private float lastshot = 0f;
    public float attackrange = 10f;

    //[Header("HP Settings")]
    //public float maxHealth;
    //public float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
       // currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        currentState = State.patrol;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //    agent.SetDestination(target.position);
        if (DetectedPlayer())
        {
            currentState = State.hunt;
            lastKnownPos = target.position;
            //Check for attack state
            if (agent.remainingDistance < attackrange)
            {
                currentState = State.attack;
            }
            else
            {
                agent.SetDestination(lastKnownPos);
            }
            agent.SetDestination(lastKnownPos);
            animator.SetTrigger("Run");

        }
        else if (currentState != State.patrol)
        {
            currentState = State.searching;
        }

        //add attack state
        if (currentState == State.attack)
        {
            if (!DetectedPlayer())
            {
                currentState = State.searching;
            }
            agent.stoppingDistance = attackrange / 3f;
            animator.SetTrigger("Attack");
            agent.SetDestination(lastKnownPos);
            RangeAttack();
        }

        if (currentState == State.searching)
        {
            agent.SetDestination(lastKnownPos);
            if (agent.remainingDistance < stoppingDistance)
            {
                currentWaypointIndex = ReturnToClosestWaypointRoute();
                agent.SetDestination(waypoints[currentWaypointIndex].position);
                currentState = State.patrol;
            }
            agent.stoppingDistance = 2f;
        }
        if (currentState == State.patrol)
        {
            Patrolling();
            agent.stoppingDistance = 2f;
        }
    }

    public void RangeAttack()
    {
        //input range attack code
        if (lastshot + rps < Time.time)
        {
            GameObject tempbullet = Instantiate(bullet, bulletspawnpos.position, Quaternion.identity);
            tempbullet.GetComponent<Rigidbody>().velocity = bulletspawnpos.forward * bulletspeed;
            lastshot = Time.time;
        }
    }
    private void Searching()
    {

    }
    private void Patrolling()
    {
        float dist = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);
        if (dist <= stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }

        RaycastHit hit;
    private bool DetectedPlayer()
    {
        if (Physics.Raycast(transform.position, (target.position + new Vector3(0,1,0)) - transform.position, out hit, viewDist))
        {
            if (hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    private int ReturnToClosestWaypointRoute()
    {
        int waypointIndex = 0;
        float tempDist = float.MaxValue;

        for (int i = 0; i < waypoints.Length; i++)
        {
            float dist = Vector3.Distance(transform.position, waypoints[i].position);
            if (dist < tempDist)
            {
                tempDist = dist;
                waypointIndex = i;
            }
        }
        return waypointIndex;
    }

    /*public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            
            Destroy(gameObject);
            Debug.Log("ha loser");
        }
        Debug.Log("hit");
    }*/
   
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, hit.point);
    }
}
