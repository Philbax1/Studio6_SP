using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyStates : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent nmAgent;

    float followRange = 50f;
    float attackRange = 1.5f;
    int attackDamage = 1;

    float distance;

    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
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

        playerHealth.TakeDamage(attackDamage);
    }

    void die()
    {

    }
}
