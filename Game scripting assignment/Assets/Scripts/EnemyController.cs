using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    #region 

    private NavMeshAgent enemyNavMesh = null;
    private EnemyStats enemyStats = null;

    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject rayEmitter = null;

    private Material material;

    private RaycastHit hit;

    private int groundLayer = 9;

    private bool forwardHitObstacle = false;
    private bool leftHitObstacle = false;
    private bool rightHitObstacle = false;

    private bool hitPlayer = false;

    private enum State
    {
        PATROL,
        CHASE
    }

    private State state;

    #endregion


    //In start, the nullCheck would throw a warning because it couldn't find the NavMeshAgent. In Awake() it does work.
    private void Awake()
    {
        enemyNavMesh = GetComponent<NavMeshAgent>();

        enemyStats = GetComponent<EnemyStats>();

        material = rayEmitter.GetComponent<Renderer>().material;
        material.color = Color.green;
    }

    private void Start()
    {
        nullChecks();

        state = State.PATROL;
    }

    private void Update()
    {
        drawRays(Vector3.forward, enemyStats.maxViewDistance, Color.red, Color.green);
        //drawRays(Vector3.left, 2, Color.red, Color.green);
        //drawRays(Vector3.right, 2, Color.red, Color.green);

        switch (state)
        {
            case State.PATROL:
                patrolState();
                break;

            case State.CHASE:

                break;
        }
    }

    private void drawRays(Vector3 direction, int viewRadius, Color rayColorCollision, Color rayColorNoCollision)
    {
        if (Physics.Raycast(rayEmitter.transform.position, transform.TransformDirection(direction), out hit, viewRadius))
        {
            if (hit.transform.gameObject.layer == groundLayer)
            {
                forwardHitObstacle = true;
            }
        }
        else 
        {
            forwardHitObstacle = false;
        }

        if (forwardHitObstacle)
        {
            Debug.DrawRay(rayEmitter.transform.position, transform.TransformDirection(direction) * viewRadius, rayColorCollision);
        }

        if (!forwardHitObstacle)
        {
            Debug.DrawRay(rayEmitter.transform.position, transform.TransformDirection(direction) * viewRadius, rayColorNoCollision);
        }
    }

    private void patrolState()
    {
        if (forwardHitObstacle)
        {
            transform.Rotate(0f, Random.Range(-45, 46), 0f);
            material.color = Color.Lerp(Color.red, Color.blue, 0.5f);
        }
        else
        {
            transform.position += transform.forward * Time.deltaTime * enemyStats.moveSpeed;
            material.color = Color.Lerp(Color.red, Color.blue, 1);
        }
    }

    private void detectPlayer()
    {
        ////I know there are way more efficient and better ways to handle this. This is just temporary, to see if my idea works and get some of my motivation back. That's been shit lately.

    }

    private void chasePlayer()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= enemyStats.maxViewDistance)
        {
            //transform.LookAt(player.transform);
            enemyNavMesh.SetDestination(player.transform.position);
            enemyNavMesh.speed += 0.05f;
        }
    }

    //Wrote this method to satisfy part of the "Excellent" criteria in the rubric.
    private void nullChecks()
    {
        if (enemyNavMesh == null)
        {
            Debug.Log("Enemy NavMesh Agent is null. Check if the GetComponent is written correctly, or drag the NavMesh component in the EnemyController script.");
        }

        if (enemyStats == null)
        {
            Debug.Log("The EnemyStats script is null. Check if the GetComponent is written correctly, or serialize & drag the NavMesh component in the EnemyController script.");
        }

        if (player == null)
        {
            Debug.Log("Player is null. Insert the Player gameobject into the slot in the EnemyController script.");
        }
    }
}
