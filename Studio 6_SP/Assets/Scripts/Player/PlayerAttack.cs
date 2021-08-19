 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public enemyStates enemy;
    public CharacterController charCtrl;
    public GameObject playerBody;

    public int playerAttackDamage = 1;

    float distance;
    float range = 8f;

    // Start is called before the first frame update
    void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<enemyStates>();

        charCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance = Vector3.Distance(player.position, transform.position);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            attack();
        }
    }

    void attack()
    {
        RaycastHit hit;

        if(Physics.Raycast(playerBody.transform.position, playerBody.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            
            enemy = hit.transform.GetComponent<enemyStates>();

            if(enemy != null)
            {

                enemy.enemyTakeDamage(playerAttackDamage);
            }
        }

    }
}
