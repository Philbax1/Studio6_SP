using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinManager : MonoBehaviour
{
    public int scoreCounter = 0;
    public TextMeshProUGUI scoreUIText;
    
// Start is called before the first frame update
void Start()
{
    scoreUIText.text = "x0";
}
// Update is called once per frame
void Update()
{
}

public void coinInteraction()
{
    scoreCounter += 1;
    scoreUIText.text = "x" + scoreCounter;
}
}
