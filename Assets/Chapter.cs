using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChapter", menuName = "Chapter", order = 0)]
public sealed class Chapter : ScriptableObject
{
    public Sprite backgroundImage;
    public Message[] messages;
    public Branch[] nextBranches = Array.Empty<Branch>();
}

