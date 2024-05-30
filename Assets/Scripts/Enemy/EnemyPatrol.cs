using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public Transform patrolpoint1;
    public Transform patrolpoint2;
    public float moveSpeed = 2f;
    public float chaseSpeed = 3.5f;

    public float detectionRange = 5f;
    public float losePlayerrange = 7f;

    public Transform player;

    private Transform currentTarget;
    private bool isChasing = false;
    private bool playerDetected= false;
    public static bool UI = false;
    // Start is called before the first frame update
    void Start()
    {
        currentTarget = patrolpoint1 ;
        Flip();
        
    }
    private void Awake()
    {
        GameObject[] playerObject = GameObject.FindGameObjectsWithTag("Player");
        foreach (var pl in playerObject)
        {
            if (pl.GetComponent<Transform>())
            {

                player = pl.GetComponent<Transform>();
                //Debug.Log(player);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer =Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            playerDetected = true;
            isChasing = true;
            

        }
        else if(distanceToPlayer > losePlayerrange)
        {
            playerDetected = false;
          

        }
        if (isChasing && playerDetected)
        {
            ChasePlayer();
            UI = true;
        }
        else
        {
            if (isChasing && !playerDetected) 
            { 
                isChasing=false;
                currentTarget = FindClosestPatrolPoint();
                UI = false;

            }
            Patrol();
        }
        
    }
    private void Patrol()
    {
        transform.position= Vector2.MoveTowards(transform.position,currentTarget.position, moveSpeed*Time.deltaTime);

        if (Vector2.Distance(transform.position, currentTarget.position)< 0.1f)
        {
            Flip();
            currentTarget = currentTarget==patrolpoint1 ? patrolpoint2 : patrolpoint1 ;
        }

    }
    private void ChasePlayer()
    {
        transform.position=Vector2.MoveTowards(transform.position,player.position, chaseSpeed*Time.deltaTime);

        if (player.position.x< transform.position.x)
        {
            if ( transform.localScale.x > 0 )
            {
                Flip();
            }
        }
        else if (player.position.x> transform.position.x)
        {

            if (transform.localScale.x < 0 )
            {
                Flip();
            }
        }

    }
    private Transform FindClosestPatrolPoint()
    {
        float distanceToPatrolPoint1 = Vector2.Distance(transform.position, patrolpoint1.position);

        float distanceToPatrolPoint2 = Vector2.Distance(transform.position, patrolpoint2.position);


        return distanceToPatrolPoint1 < distanceToPatrolPoint2 ? patrolpoint1 : patrolpoint2;
    }
    public void Flip()
    {
        Vector3 localScale=transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
