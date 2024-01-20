using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChapter", menuName = "Chapter", order = 0)]
public sealed class Chapter : ScriptableObject
{
    public Sprite BackgroundImage;
    public Message[] messages;
}

