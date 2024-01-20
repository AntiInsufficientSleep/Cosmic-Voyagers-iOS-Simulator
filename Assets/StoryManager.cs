using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class StoryManager : MonoBehaviour
{
    [SerializeField]
    private Chapter currentChapter;

    [SerializeField]
    private Image background;

    [SerializeField]
    private Image characterImage;

    [SerializeField]
    private TextMeshProUGUI message;

    [SerializeField]
    private TextMeshProUGUI characterName;

    [SerializeField]
    private GameObject selection2;
    [SerializeField]
    private Button selection2option1;
    [SerializeField]
    private TextMeshProUGUI selection2option1text;
    [SerializeField]
    private Button selection2option2;
    [SerializeField]
    private TextMeshProUGUI selection2option2text;

    [SerializeField]
    private GameObject selection3;
    [SerializeField]
    private Button selection3option1;
    [SerializeField]
    private TextMeshProUGUI selection3option1text;
    [SerializeField]
    private Button selection3option2;
    [SerializeField]
    private TextMeshProUGUI selection3option2text;
    [SerializeField]
    private Button selection3option3;
    [SerializeField]
    private TextMeshProUGUI selection3option3text;

    [SerializeField]
    private GameObject selection4;
    [SerializeField]
    private Button selection4option1;
    [SerializeField]
    private TextMeshProUGUI selection4option1text;
    [SerializeField]
    private Button selection4option2;
    [SerializeField]
    private TextMeshProUGUI selection4option2text;
    [SerializeField]
    private Button selection4option3;
    [SerializeField]
    private TextMeshProUGUI selection4option3text;
    [SerializeField]
    private Button selection4option4;
    [SerializeField]
    private TextMeshProUGUI selection4option4text;

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
            if (MessageIndex < currentChapter.messages.Length)
            {
                MessageIndex++;
                SetMessage();
            }
            else
            {
                SetNextChapter();
            }
        }
    }

    private void SetMessage()
    {
        Message message = currentChapter.messages[MessageIndex];

        background.sprite = currentChapter.backgroundImage;

        characterImage.sprite = message.CharacterImage;
        characterName.text = message.CharacterName;

        StartCoroutine(TypeMessage(message.Content));
    }

    private void SetNextChapter()
    {
        switch (currentChapter.nextBranches.Length)
        {
            case 0:
                return;
            case 1:
                MessageIndex = 0;
                currentChapter = currentChapter.nextBranches[0].chapter;
                SetMessage();
                break;
            case 2:
                
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                Debug.LogError("Unexpected number of next chapters");
                break;
        }
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
