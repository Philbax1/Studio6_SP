using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class randomBoxPickup : MonoBehaviour
{
    public GameObject player;
    float distance;
    float boxDistance = 2f;
    int ranNum;

    public coinManager coinManager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coinManager = GameObject.FindGameObjectWithTag("coinManger").GetComponent<coinManager>();
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance <= boxDistance)
        {
            ranNum = 4/*Random.Range(1,100)*/;
            Debug.Log(ranNum);
            
            if(ranNum >= 4)
            {
                coinManager.coinInteraction();
                this.gameObject.SetActive(false);

                Debug.Log("Coin Received, will need to make some speical affect to show");
            }
            if(ranNum == 1)
            {
                Debug.Log("Special ability 1");
            }
            if(ranNum == 2)
            {
                Debug.Log("Special ability 2");
            }
            if(ranNum == 3)
            {
                Debug.Log("Special ability 3");
            }

            this.gameObject.SetActive(false);
        }
    }
}
