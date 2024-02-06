using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerDamage : MonoBehaviour
{
    private TMP_Text lifeText;
    private int lifeScoreCount;
    private bool canDamage;


    void Awake(){

        lifeText = GameObject.Find("PlayerHealth").GetComponent<TMP_Text>();
        lifeScoreCount = 3;
        lifeText.text = "x"+lifeScoreCount;

        canDamage = true;
    }

    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        
    }

    public void DealDamage(){
        if(canDamage){
            lifeScoreCount--;
            
            if(lifeScoreCount>=0){
                lifeText.text = "x"+lifeScoreCount;
            }
            if(lifeScoreCount==0){
                //GAME END
                Time.timeScale = 0;
                StartCoroutine(RestartGame());
            }
            canDamage = false;
            StartCoroutine(WaitForDamage());
        }
    }
    IEnumerator WaitForDamage(){
        yield return new WaitForSeconds(0.5f);
        canDamage=true;
    }
    IEnumerator RestartGame(){
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("SushantDemo");
    }


}//end
