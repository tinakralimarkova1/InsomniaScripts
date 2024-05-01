using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// [CreateAssetMenu(fileName = "NewBackground", menuName = "Data/New Background")]
// [System.Serializable]

public class Background : MonoBehaviour
{
    public Sprite image;
    public RuntimeAnimatorController myController;
    public SpriteRenderer SR;
    public Animator Ani;
    public AudioSource audioSource;
   

    void Start(){
        SR.sprite = image;
        Ani.runtimeAnimatorController = myController;
        audioSource = GetComponent<AudioSource>(); 
        myController = GetComponent<RuntimeAnimatorController>():
        

    }


    void Update(){
    //    if(AudioSource.clip != null &&  AudioSource.enabled){
    //         AudioSource.Play();
    //    }
    }

    // public void UpdateBackground(Sprite bg_image, RuntimeAnimatorController bg_myController){
    //     image = bg_image;
    //     myController = bg_myController;
    //     //SR.sprite = bg_image;
    //     //Ani.runtimeAnimatorController = bg_myController;
    // }
    public void Play_SFX(){
        audioSource.Play();
    }
    
}
