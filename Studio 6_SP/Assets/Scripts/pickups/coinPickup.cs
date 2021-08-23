using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinPickup : MonoBehaviour
{
    public GameObject player;
    float distance;
    float coinPickupDistance = 1.45f;
    public TextMeshProUGUI scoreUIText;

// Start is called before the first frame update
void Start()
{
    player = GameObject.FindGameObjectWithTag("Player");
    scoreUIText.text = "x0";
}

// Update is called once per frame
void Update()
{
    distance = Vector3.Distance(player.transform.position, transform.position);

    if(distance <= coinPickupDistance)
    {
        GameObject.Find("pickupsManager").GetComponent<coinCounter>().scoreCounter += 1;
        scoreUIText.text = "x" + GameObject.Find("pickupsManager").GetComponent<coinCounter>().scoreCounter;

        this.gameObject.SetActive(false);
    }
}
}
