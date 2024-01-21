using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class StoryManager : MonoBehaviour
{
    private static WaitForSeconds delay = new(0.1f);

    private Chapter previousChapter;
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
    private GameObject pauseButton;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private TMP_InputField mainCharNameInputField;

    [SerializeField]
    private GameObject selection2;
    [SerializeField]
    private TextMeshProUGUI selection2option1text;
    [SerializeField]
    private TextMeshProUGUI selection2option2text;

    [SerializeField]
    private GameObject selection3;
    [SerializeField]
    private TextMeshProUGUI selection3option1text;
    [SerializeField]
    private TextMeshProUGUI selection3option2text;
    [SerializeField]
    private TextMeshProUGUI selection3option3text;

    [SerializeField]
    private GameObject selection4;
    [SerializeField]
    private TextMeshProUGUI selection4option1text;
    [SerializeField]
    private TextMeshProUGUI selection4option2text;
    [SerializeField]
    private TextMeshProUGUI selection4option3text;
    [SerializeField]
    private TextMeshProUGUI selection4option4text;

    [SerializeField]
    private AudioSource audioSource;

    public int MessageIndex { get; private set; } = 0;

    public string MainCharacterName { get; set; } = "けんと";

    private bool isFinishMessage = true;
    private bool isMessageSkipRequested = false;
    private bool isMessageInterrupted = false;
    private bool isNextMessageRequested = false;
    private bool isBGMOn = true;
    private bool isBGMNull = true;

    public void onSelection2Option1Click()
    {
        selection2.SetActive(false);
        SetFirstNextBranch();
    }

    public void onSelection2Option2Click()
    {
        selection2.SetActive(false);
        SetSecondNextBranch();
    }

    public void onSelection3Option1Click()
    {
        selection3.SetActive(false);
        SetFirstNextBranch();
    }

    public void onSelection3Option2Click()
    {
        selection3.SetActive(false);
        SetSecondNextBranch();
    }

    public void onSelection3Option3Click()
    {
        selection3.SetActive(false);
        SetThirdNextBranch();
    }

    public void onSelection4Option1Click()
    {
        selection4.SetActive(false);
        SetFirstNextBranch();
    }

    public void onSelection4Option2Click()
    {
        selection4.SetActive(false);
        SetSecondNextBranch();
    }

    public void onSelection4Option3Click()
    {
        selection4.SetActive(false);
        SetThirdNextBranch();
    }

    public void onSelection4Option4Click()
    {
        selection4.SetActive(false);
        SetFourthNextBranch();
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseButton.SetActive(false);
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseButton.SetActive(true);
            pauseMenu.SetActive(false);
        }
    }

    public void SwitchBGM()
    {
        isBGMOn = !isBGMOn;

        if (isBGMNull)
        {
            return;
        }

        if (isBGMOn)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    public void GoBack()
    {
        isMessageInterrupted = true;
        message.text = "";
        SetCurrentChapter(previousChapter);
    }

    public void RequestNextMessage()
    {
        isNextMessageRequested = true;
    }

    public void onMainCharNameInputFieldEndEdit()
    {
        MainCharacterName = mainCharNameInputField.text;
    }

    private void Start()
    {
        SetCurrentChapter(currentChapter);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isNextMessageRequested = true;
        }

        ProcessNextMessageRequest();
    }

    private void ProcessNextMessageRequest()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        if (isNextMessageRequested)
        {
            isNextMessageRequested = false;

            if (isFinishMessage)
            {
                if (MessageIndex < currentChapter.messages.Length - 1)
                {
                    MessageIndex++;
                    SetMessage();
                }
                else
                {
                    SetNextChapter();
                }
            }
            else
            {
                isMessageSkipRequested = true;
            }
        }
    }

    private void SetMessage()
    {
        Message message = currentChapter.messages[MessageIndex];

        Sprite image = message.CharacterImage;

        if (!ReferenceEquals(image, null))
        {
            characterImage.sprite = image;
        }
        else
        {
            Debug.LogError("Character image is null");
        }

        characterName.text = message.CharacterName.Replace("主人公", MainCharacterName);

        StartCoroutine(TypeMessage(message.Content.Replace("[主人公の名前]", MainCharacterName)));
    }

    private void SetCurrentChapter(Chapter chapter)
    {
        previousChapter = currentChapter;
        MessageIndex = 0;
        currentChapter = chapter;

        Sprite image = chapter.backgroundImage;

        if (!ReferenceEquals(image, null))
        {
            background.sprite = image;
        }
        else
        {
            Debug.LogError("Background image is null");
        }

        AudioClip audioClip = chapter.backGroundMusic;

        if (!ReferenceEquals(audioClip, null))
        {
            isBGMNull = false;
            audioSource.clip = audioClip;

            if (isBGMOn)
            {
                audioSource.Play();
            }
        }
        else
        {
            isBGMNull = true;
            Debug.LogError("Background music is null");
            audioSource.Stop();
        }

        SetMessage();
    }

    private void SetFirstNextBranch()
    {
        if (currentChapter.nextBranches.Length < 1)
        {
            Debug.LogError("Unexpected number of next chapters");
            return;
        }

        SetCurrentChapter(currentChapter.nextBranches[0].chapter);
    }

    private void SetSecondNextBranch()
    {
        if (currentChapter.nextBranches.Length < 2)
        {
            Debug.LogError("Unexpected number of next chapters");
            return;
        }

        SetCurrentChapter(currentChapter.nextBranches[1].chapter);
    }

    private void SetThirdNextBranch()
    {
        if (currentChapter.nextBranches.Length < 3)
        {
            Debug.LogError("Unexpected number of next chapters");
            return;
        }

        SetCurrentChapter(currentChapter.nextBranches[2].chapter);
    }

    private void SetFourthNextBranch()
    {
        if (currentChapter.nextBranches.Length < 4)
        {
            Debug.LogError("Unexpected number of next chapters");
            return;
        }

        SetCurrentChapter(currentChapter.nextBranches[3].chapter);
    }

    private void SetNextChapter()
    {
        switch (currentChapter.nextBranches.Length)
        {
            case 0:
                break;

            case 1:
                SetCurrentChapter(currentChapter.nextBranches[0].chapter);
                break;

            case 2:
                selection2.SetActive(true);
                selection2option1text.text = currentChapter.nextBranches[0].choiceMessage;
                selection2option2text.text = currentChapter.nextBranches[1].choiceMessage;
                break;

            case 3:
                selection3.SetActive(true);
                selection3option1text.text = currentChapter.nextBranches[0].choiceMessage;
                selection3option2text.text = currentChapter.nextBranches[1].choiceMessage;
                selection3option3text.text = currentChapter.nextBranches[2].choiceMessage;
                break;

            case 4:
                selection4.SetActive(true);
                selection4option1text.text = currentChapter.nextBranches[0].choiceMessage;
                selection4option2text.text = currentChapter.nextBranches[1].choiceMessage;
                selection4option3text.text = currentChapter.nextBranches[2].choiceMessage;
                selection4option4text.text = currentChapter.nextBranches[3].choiceMessage;
                break;

            default:
                Debug.LogError("Unexpected number of next chapters");
                break;
        }
    }

    private IEnumerator TypeMessage(string messageContent)
    {
        while (!isFinishMessage)
        {
            yield return delay;
        }

        message.text = "";
        isFinishMessage = false;

        foreach (char letter in messageContent.ToCharArray())
        {
            if (isMessageInterrupted)
            {
                isMessageInterrupted = false;
                break;
            }

            if (isMessageSkipRequested)
            {
                message.text = messageContent;
                isMessageSkipRequested = false;
                break;
            }

            message.text += letter;
            yield return delay;
        }

        isFinishMessage = true;
    }
}
