using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public enemyStates enemy;

    public int playerAttackDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<enemyStates>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            enemy.enemyTakeDamage(playerAttackDamage);
        }
    }
}
