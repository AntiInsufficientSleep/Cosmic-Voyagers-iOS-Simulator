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

    private bool isFinishMessage = false;

    private void Start()
    {
        SetStoryElement(StoryIndex, MessageIndex);
    }

    private void Update()
    {
        if (isFinishMessage && Input.GetKeyDown(KeyCode.Return))
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
        Story story = storyData[storyIndex].stories[messageIndex];

        background.sprite = story.Background;
        characterName.text = story.CharacterName;

        StartCoroutine(TypeMessage(story.Message));
    }

    private IEnumerator TypeMessage(string message)
    {
        this.message.text = "";
        isFinishMessage = false;

        foreach (char letter in message.ToCharArray())
        {
            this.message.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

        isFinishMessage = true;
    }
}
