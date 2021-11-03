using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickup : MonoBehaviour
{
    public GameObject player;
    float distance;
    float coinPickupDistance = 1.45f;

    public coinManager coinManager;
    public playSounds playSounds;

// Start is called before the first frame update
void Start()
{
    player = GameObject.FindGameObjectWithTag("Player");
    coinManager = GameObject.FindGameObjectWithTag("coinManger").GetComponent<coinManager>(); 
    playSounds = GameObject.FindGameObjectWithTag("sound").GetComponent<playSounds>();
}

// Update is called once per frame
void Update()
{
    distance = Vector3.Distance(player.transform.position, transform.position);

    if(distance <= coinPickupDistance)
    {
        playSounds.coinSoundPlay();
        coinManager.coinInteraction();
        this.gameObject.SetActive(false);
    }
}


}
