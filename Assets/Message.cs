using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public sealed class Message
{
    public Sprite CharacterImage;

    [TextArea]
    public string Content = "";    
    public string CharacterName = "";
}
