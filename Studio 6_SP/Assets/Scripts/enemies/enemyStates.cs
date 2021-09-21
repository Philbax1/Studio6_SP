using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyStates : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent nmAgent;

    int enemyMaxHealth = 1;
    int enemyCurrentHealth;

    private string objectTag; 

    float followRange = 50f;
    float attackRange = 1.5f;
    int attackDamage = 1;

    float SharkAttackRange = 3f;
    int SharkAttackDamage = 1;

    bool readyAttack = true;

    float distance;

    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        objectTag = gameObject.tag;

        enemyCurrentHealth = enemyMaxHealth; //set enemy health
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance <= followRange)
        {
            followPlayer();

            if(objectTag == "sharkEnemy")
                if(distance <= SharkAttackRange && readyAttack)
                {
                    StartCoroutine("attackPlayer");
                } 
            else
            {
               if(distance <= attackRange && readyAttack)
                {
                    StartCoroutine("attackPlayer");
                } 
            } 
        }
        else neutralPatrol();
    }

    void neutralPatrol()
    {
        //Debug.Log("enemy is in neutral state");
    }

    void followPlayer()
    {
        nmAgent.SetDestination(player.transform.position);
    }

    IEnumerator attackPlayer()
    {
        Debug.Log("enemy is attacking player");

        if(objectTag == "sharkEnemy") playerHealth.TakeDamage(SharkAttackDamage, transform);
        else playerHealth.TakeDamage(attackDamage, transform);
        
        readyAttack = false;
        yield return new WaitForSeconds(2f);
        readyAttack = true;
    }

    public void enemyTakeDamage(int damage)
    {   
        enemyCurrentHealth -= damage;
        Debug.Log("damage done");
        
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
}
