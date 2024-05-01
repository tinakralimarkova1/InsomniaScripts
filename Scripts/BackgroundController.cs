using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{

    public bool isSwitched = false;
    public Background background1;
    public Background background2;
    
    public Animator animator;
    //public Animator background_animator;

    public void SwitchImage(Sprite bg_image, RuntimeAnimatorController bg_myController, AudioClip SFXinAnimation)
    {
        if (!isSwitched)
        {
            //background1.image = bg_image;
            //background1.myController = bg_myController;
            background2.SR.sprite = bg_image;
            background2.Ani.runtimeAnimatorController = bg_myController;
            background2.audioSource.clip = SFXinAnimation;



            animator.SetTrigger("SwitchFirst");
        }
        else
        {
            //background2.image = bg_image;
            //background2.myController = bg_myController;
            background1.SR.sprite = bg_image;
            background1.Ani.runtimeAnimatorController = bg_myController;
            background1.audioSource.clip = SFXinAnimation;
            //background2.UpdateBackground(image,myController);
            
            //ani1.Play();
            animator.SetTrigger("SwitchSecond");
        }
        isSwitched = !isSwitched;
    }

    public void SetImage(Sprite bg_image, RuntimeAnimatorController bg_myController, AudioClip SFXinAnimation)
    {
        if (!isSwitched)
        {
            background1.image = bg_image;
            background1.myController = bg_myController;
            background1.audioSource.clip = SFXinAnimation;
            //background2.SR.sprite = bg_image;
            //background2.Ani.runtimeAnimatorController = bg_myController;
            //background2.SetBackground(image,myController);
            
            //ani2.Play();
        }
        else
        {
            background2.image = bg_image;
            background2.myController = bg_myController;
            background2.audioSource.clip = SFXinAnimation;
            //background1.SR.sprite = bg_image;
            //background1.Ani.runtimeAnimatorController = bg_myController;
            //background1.SetBackground(image,myController);            
            //ani1.Play();
        }
    }
}
