using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSounds : MonoBehaviour
{
    public AudioSource audioDataMystery;
    public AudioSource audioDataCoin;

    // Start is called before the first frame update
    void Start()
    {
        //audioDataMystery = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mysteryBoxSoundPlay()
    {
        audioDataMystery.Play();
    }
    public void coinSoundPlay()
    {
        audioDataCoin.Play();
    }
}
