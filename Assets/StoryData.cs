using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewData", menuName = "StoryData", order = 0)]
public sealed class StoryData : ScriptableObject
{
    public List<Story> stories = new();
}

[System.Serializable]
public sealed class Story
{
    public Sprite Background;
    public Sprite CharacterImage;
    
    [TextArea]
    public string Message = "";
    public string CharacterName = "";
}
