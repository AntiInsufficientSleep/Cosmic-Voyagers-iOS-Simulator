using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    [SerializeField]
    private StoryData[] storyData;

    [SerializeField]
    private Image background;

    [SerializeField]
    private TextMeshProUGUI message;

    [SerializeField]
    private TextMeshProUGUI characterName;

    public int StoryIndex { get; private set; } = 0;

    public int MessageIndex { get; private set; } = 0;

    private void Start()
    {
        SetStoryElement(StoryIndex, MessageIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (MessageIndex < storyData[StoryIndex].stories.Count)
            {
                MessageIndex++;
            }
            else
            {
                StoryIndex++;
                MessageIndex = 0;
            }

            SetStoryElement(StoryIndex, MessageIndex);
        }
    }

    private void SetStoryElement(int storyIndex, int messageIndex)
    {
        var story = storyData[storyIndex].stories[messageIndex];

        background.sprite = story.Background;
        message.text = story.Message;
        characterName.text = story.CharacterName;
    }
}
