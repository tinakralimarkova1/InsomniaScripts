using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameScene currentScene;
    public TextBoxController bottomBar;
    public BackgroundController backgroundController;
    public ChooseController chooseController;
    public AudioController audioController;
    public List<GameScene> recordedScenes= new List<GameScene>();


    
    private State state = State.IDLE;

    private enum State
    {
        IDLE, ANIMATE, CHOOSE
    }


    void Start()
    {
        if (currentScene is StoryScene)
        {

            StoryScene storyScene = currentScene as StoryScene;

            // recordedScenes.Add(storyScene);
            // if (recordedScenes.Contains(storyScene.decidingScene)){
            //     storyScene.nextScene = storyScene.alternateScene;
            // }
            backgroundController.SetImage(storyScene.image, storyScene.myController,storyScene.SFXinAnimation);
            bottomBar.PlayScene(storyScene);
            PlayAudio(storyScene.sentences[0]);

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bottomBar.IsCompleted())
        {
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    if (state == State.IDLE && bottomBar.IsLastSentence())
                    {
                        
                        

                        
                        PlayScene((currentScene as StoryScene).nextScene);
                        
                    }
                    else
                    {
                        bottomBar.PlayNextSentence();
                        PlayAudio((currentScene as StoryScene).sentences[bottomBar.GetSentenceIndex()]);
                    }
                
                }

        
        }
    }

    public void PlayScene(GameScene scene)
    {   
        
        StartCoroutine(SwitchScene(scene));
    }

    private IEnumerator SwitchScene(GameScene scene)
    {
        state = State.ANIMATE;
        currentScene = scene;
        bottomBar.Hide();
        yield return new WaitForSeconds(0.5f);
        if (scene is StoryScene)
        {
            StoryScene storyScene = scene as StoryScene;
            backgroundController.SwitchImage(storyScene.image, storyScene.myController,storyScene.SFXinAnimation);
            PlayAudio(storyScene.sentences[0]);
            yield return new WaitForSeconds(0.5f);
            bottomBar.ClearText();
            bottomBar.Show();
            yield return new WaitForSeconds(0.5f);
            bottomBar.PlayScene(storyScene);
            state = State.IDLE;
        }
        else if (scene is ChooseScene)
        {
            state = State.CHOOSE;
            chooseController.SetupChoose(scene as ChooseScene);
        }
    }

    private void PlayAudio(StoryScene.Sentence sentence)
    {
        audioController.PlayAudio(sentence.music);
    } 
}
