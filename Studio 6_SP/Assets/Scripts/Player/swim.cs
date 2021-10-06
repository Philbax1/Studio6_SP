using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swim : MonoBehaviour
{ 
    public CharacterController controller;
    public LayerMask water;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        water = LayerMask.GetMask("Water");
    }

    void Update()
    {
        
    }
}
