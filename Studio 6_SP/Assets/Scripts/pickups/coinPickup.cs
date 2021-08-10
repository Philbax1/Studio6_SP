using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coinPickup : MonoBehaviour
{
    public GameObject player;

    float distance;
    float coinPickupDistance = 1.2f;

    public TextMeshProUGUI scoreUIText; 
    int scoreCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreUIText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance <= coinPickupDistance){
            this.gameObject.SetActive(false);
            GameObject.Find("coin").GetComponent<coinScore>().scoreCounter += 1;
            scoreUIText.text = "x " + GameObject.Find("coin").GetComponent<coinScore>().scoreCounter;
        }
    }
}
