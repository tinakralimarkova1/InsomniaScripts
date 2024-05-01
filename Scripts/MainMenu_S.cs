using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_S : MonoBehaviour
{
    public AudioManager audioManager;

    public void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void PlayGame(){
        
        StartCoroutine(ButtonClick());
    }

    public void QuitGame(){
        StartCoroutine(QuitButton());
       
    }

    IEnumerator ButtonClick(){
        audioManager.PlaySFX(audioManager.click);
        yield return new WaitForSeconds(0.4f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Intro_Scene_1");
    }

    IEnumerator QuitButton(){
        audioManager.PlaySFX(audioManager.click);
        yield return new WaitForSeconds(0.4f);
        Application.Quit();
    }
    
}
