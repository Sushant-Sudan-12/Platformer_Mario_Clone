using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("SushantDemo");
    }
    void Update(){
        if(Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("SampleScene");
        }
        
    }
}
