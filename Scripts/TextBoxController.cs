using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxController : MonoBehaviour
{
    public TextMeshProUGUI boxText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    private StoryScene currentScene;
    private State state = State.COMPLETED;
    private Animator animator;
    private bool isHidden = false;
    public AudioSource VoiceAudio;


    private enum State
    {
        PLAYING, COMPLETED
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public int GetSentenceIndex()
    {
        return sentenceIndex;
    }

    public void Hide()
    {
        if (!isHidden)
        {
            animator.SetTrigger("Hide");
            isHidden = true;
        }
    }

    public void Show()
    {
        animator.SetTrigger("Show");
        isHidden = false;
    }

     public void ClearText()
    {
        boxText.text = "";
        personNameText.text = "";
    }

    public void PlayScene(StoryScene scene){
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();

    }




    
    public void PlayNextSentence()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));   
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.SpeakerName;
        personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;

        if(currentScene.sentences[sentenceIndex].audio){
            VoiceAudio.clip = currentScene.sentences[sentenceIndex].audio;
            VoiceAudio.Play();
        }
        else{
            VoiceAudio.Stop();
        }
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    private IEnumerator TypeText(string text)
    {
        boxText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            boxText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);

            if(++wordIndex == text.Length){
                state = State.COMPLETED;
                break;
            }
        }
    }


   
}