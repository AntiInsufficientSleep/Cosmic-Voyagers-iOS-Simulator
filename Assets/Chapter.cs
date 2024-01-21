using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChapter", menuName = "Chapter", order = 0)]
public sealed class Chapter : ScriptableObject
{
    public Sprite backgroundImage;
    public AudioClip backGroundMusic;
    public Message[] messages;
    public Branch[] nextBranches = Array.Empty<Branch>();
}

