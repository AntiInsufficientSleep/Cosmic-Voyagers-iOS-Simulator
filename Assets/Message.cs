using System;
using UnityEngine;

[Serializable]
public sealed class Message
{
    public Sprite CharacterImage;

    [TextArea]
    public string Content = "";    
    public string CharacterName = "";
}
