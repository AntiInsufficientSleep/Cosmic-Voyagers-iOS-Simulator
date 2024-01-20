using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewData", menuName = "StoryData", order = 0)]
public sealed class StoryData : ScriptableObject
{
    public Story[] stories;
}

[System.Serializable]
public sealed class Story
{
    public Sprite Background;
    [TextArea]
    public string Message = "";
    public string CharacterName = "";
}
