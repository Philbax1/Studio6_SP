using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyStates : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent nmAgent;

    float followRange = 100f;
    float attackRange = 10f;

    float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);

        if(distance <= followRange)
        {
            followPlayer();
        }
    }

    void neutralPatrol()
    {

    }

    void followPlayer()
    {
        nmAgent.SetDestination(player.position);
    }

    void attackPlayer()
    {

    }

    void die()
    {

    }
}
