using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{
    private string objectTag; 
    float distance;
    public GameObject player;
    public GameObject bolder1;

    float pressureplateDistance = 4;

    // Start is called before the first frame update
    void Start()
    {
        objectTag = gameObject.tag;
        player = GameObject.FindGameObjectWithTag("Player");
        bolder1 = GameObject.Find("boulder1");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance <= pressureplateDistance)
        {
            StartCoroutine("trap1DropBoulder");
            //this.gameObject.SetActive(false);
        }
    }

    IEnumerator trap1DropBoulder()
    {
        yield return new WaitForSeconds(2f);
    }
}
