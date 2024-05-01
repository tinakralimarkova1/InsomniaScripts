using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
[System.Serializable]

public class StoryScene : GameScene
{
    public List<Sentence> sentences;
    public Sprite image;
    public RuntimeAnimatorController myController;
    public AudioClip SFXinAnimation;
    public GameScene nextScene;
    public bool isAffected;
    public GameScene alternateScene;
    public GameScene decidingScene;
    
    
    
    
    
    [System.Serializable]

    public struct Sentence{
        public AudioClip music;
        public string text;
        public Speaker speaker;
        public AudioClip audio;

    }
    
}
public class GameScene : ScriptableObject {}