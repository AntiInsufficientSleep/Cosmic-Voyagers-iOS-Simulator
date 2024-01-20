using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class StoryManager : MonoBehaviour
{
    [SerializeField]
    private Chapter[] chapters;

    [SerializeField]
    private Image background;

    [SerializeField]
    private Image characterImage;

    [SerializeField]
    private TextMeshProUGUI message;

    [SerializeField]
    private TextMeshProUGUI characterName;

    [SerializeField]
    private GameObject Selection2;
    [SerializeField]
    private GameObject Selection3;
    [SerializeField]
    private GameObject Selection4;

    public int ChapterIndex { get; private set; } = 0;

    public int MessageIndex { get; private set; } = 0;

    private bool isFinishMessage = false;

    private void Start()
    {
        SetMessage();
    }

    private void Update()
    {
        if (isFinishMessage && Input.GetKeyDown(KeyCode.Return))
        {
            if (MessageIndex < chapters[ChapterIndex].messages.Length)
            {
                MessageIndex++;
            }
            else
            {
                ChapterIndex++;
                MessageIndex = 0;
            }

            SetMessage();
        }
    }

    private void SetMessage()
    {
        Chapter chapter = chapters[ChapterIndex];
        Message message = chapter.messages[MessageIndex];

        background.sprite = chapter.BackgroundImage;

        characterImage.sprite = message.CharacterImage;
        characterName.text = message.CharacterName;

        StartCoroutine(TypeMessage(message.Content));
    }

    private IEnumerator TypeMessage(string messageContent)
    {
        message.text = "";
        isFinishMessage = false;

        foreach (char letter in messageContent.ToCharArray())
        {
            message.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

        isFinishMessage = true;
    }
}
