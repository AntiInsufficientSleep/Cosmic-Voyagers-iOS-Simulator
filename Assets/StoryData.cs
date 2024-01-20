using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewData", menuName = "StoryData", order = 0)]
public sealed class StoryData : ScriptableObject
{
    public Sprite BackgroundImage;
    public Story[] stories;
}

[System.Serializable]
public sealed class Story
{
    public Sprite CharacterImage;

    [TextArea]
    public string Message = "";    
    public string CharacterName = "";
}
