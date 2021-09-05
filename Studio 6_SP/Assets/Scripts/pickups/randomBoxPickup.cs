using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomBoxPickup : MonoBehaviour
{
    public GameObject player;
    float distance;
    float boxDistance = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance <= boxDistance)
        {
            this.gameObject.SetActive(false);
        }
    }
}
