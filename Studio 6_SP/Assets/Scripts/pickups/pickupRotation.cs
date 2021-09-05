using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupRotation : MonoBehaviour
{
    public float rotateCoinSpeed = 100f;
    public float rotateMBoxSpeed = 40f;
    private string objectTag; 

// Start is called before the first frame update
void Start()
{
    objectTag = gameObject.tag;
}
// Update is called once per frame
void Update()
{
    if(objectTag == "pickupCoin")
    {
        transform.Rotate(Vector3.right * rotateCoinSpeed * Time.deltaTime);
    }
    if(objectTag == "pickupMysteryBox")
    {
        transform.Rotate(Vector3.up * rotateMBoxSpeed * Time.deltaTime);
    }
}
}