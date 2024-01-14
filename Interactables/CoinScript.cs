using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinScript : MonoBehaviour
{
    public TMP_Text coinTextScore;
    private AudioSource audioManager;
    private int scoreCount = 0; 
    
    void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }

    void Start()
    {
        coinTextScore = GameObject.Find("CoinText").GetComponent<TMP_Text>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag=="Coin"){
            target.gameObject.SetActive(false);
            scoreCount++;
            coinTextScore.text = "x" + scoreCount;
            audioManager.Play();
        }
        
    }
}
