using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyStates : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent nmAgent;

    float followRange = 50f;
    float attackRange = 5f;

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
            if(distance <= attackRange)
            {
                attackPlayer();
            }
            else followPlayer();
        }
        else neutralPatrol();
    }

    void neutralPatrol()
    {
        Debug.Log("enemy is in neutral state");
    }

    void followPlayer()
    {
        nmAgent.SetDestination(player.position);
    }

    void attackPlayer()
    {
        Debug.Log("enemy is attacking player");
    }

    void die()
    {

    }
}
