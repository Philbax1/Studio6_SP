using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyStates : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent nmAgent;
    public Rigidbody enemyRigidBody;

    int enemyMaxHealth = 3;
    int enemyCurrentHealth;

    float followRange = 50f;
    float attackRange = 1.5f;
    int attackDamage = 1;

    bool readyAttack = true;

    float distance;

    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth; //set enemy health
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);

        if(distance <= followRange)
        {
            if(distance <= attackRange && readyAttack)
            {
                StartCoroutine("attackPlayer");
            }
            else followPlayer();
        }
        else neutralPatrol();
    }

    void neutralPatrol()
    {
        //Debug.Log("enemy is in neutral state");
    }

    void followPlayer()
    {
        nmAgent.SetDestination(player.position);
    }

    IEnumerator attackPlayer()
    {
        Debug.Log("enemy is attacking player");
        playerHealth.TakeDamage(attackDamage, transform);
        
        readyAttack = false;
        yield return new WaitForSeconds(1f);
        readyAttack = true;
    }

    public void enemyTakeDamage(int damage)
    {   
        enemyCurrentHealth -= damage;
        Debug.Log("damage done");
        
        enemyRigidBody.AddForce(transform.up * 100f);

        if(enemyCurrentHealth <= 0)
        {
            die();  
        }
    }

    void die()
    {
        Destroy(gameObject, 1);

        //Debug.Log("ENEMY HAS DIED");
    }

    public void applyForceToEnemy()
    {    
        Vector3 dir = player.position - transform.position;  // Calculate Angle Between the collision point and the player

        enemyRigidBody.AddForce(transform.up * 10);
    }
}
