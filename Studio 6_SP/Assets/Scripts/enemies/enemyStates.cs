using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStates : MonoBehaviour
{
    public transform player;
    public navmesh

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
        distance = Vector3(player.position, transform.position);

        if(distance =< followRange)
        {

        }
        if()
        {

        }
    }

    void neutralPatrol()
    {

    }

    void followPlayer()
    {

    }

    void attackPlayer()
    {

    }

    void die()
    {

    }
}
