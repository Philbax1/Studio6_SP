using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlatforms : MonoBehaviour
{
    public float platformSpinSpeed = 5f;
    private string objectTag; 

    float distance;
    public GameObject player;
    float platformDistance = 4;


// Start is called before the first frame update
void Start()
{
    objectTag = gameObject.tag;
    player = GameObject.FindGameObjectWithTag("Player");
}
// Update is called once per frame
void Update()
{
    if(objectTag == "spinPlatform")
    {
        transform.Rotate(Vector3.up * platformSpinSpeed * Time.deltaTime);
        //transform.Rotate(Vector3.back * platformSpinSpeed * Time.deltaTime);
    }
    if(objectTag == "upDownPlatform")
    {
        
    }
    if(objectTag == "tipPlatform")
    {

        distance = Vector3.Distance(player.transform.position, transform.position);
        
        if(distance <= platformDistance)
        {
            StartCoroutine("dropPlatfrom");
            //this.gameObject.SetActive(false);
        }
    }
}

IEnumerator dropPlatfrom()
{
    yield return new WaitForSeconds(.5f);
    //this.gameObject.GetComponent<Rigidbody>().useGravity = true;
    this.GetComponent<Buoyancy>().enabled = false;
}

}