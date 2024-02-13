using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text textBox, nameBox;

    [Header("Text File")]
    [SerializeField] private TextAsset textAsset;

    private float textSpeed;
    private int index;
    private List<string> textList = new List<string>();
    private bool textFinished = true;

    const float defaultTextSpeed = 0.07f;

    // Awake is called before the first frame update, before OnEnable being called
    private void Awake()
    {
        textSpeed = defaultTextSpeed;
        GetTextFromFile(textAsset);
    }

    // OnEnable helps to initial the dialogue boxes
    private void OnEnable()
    {
        nameBox.text = textList[index].Substring(2);
        index++;
        //textBox.text = textList[index];
        //index++;
        StartCoroutine(SetTextBox(false));
    }

    // Update is called once per frame
    private void Update()
    {
        string line;
        if (index < textList.Count && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            if(textFinished)
            {
                textSpeed = defaultTextSpeed;
                line = textList[index];
                if (line.StartsWith("//"))
                {
                    nameBox.text = line.Substring(2);
                    index++;
                    //textBox.text = textList[index];
                    //index++;
                    StartCoroutine(SetTextBox(false));
                }
                else
                {
                    //textBox.text += "\n" + line;
                    //index++;
                    StartCoroutine(SetTextBox(true));
                }
            }
            else
            {
                textSpeed = 0f;
            }
        }
        else if (index >= textList.Count)
        {
            gameObject.SetActive(false);
        }
    }

    private void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineText = file.text.Split('\n');

        foreach (var line in lineText)
        {
            textList.Add(line);
        }
    }

    private IEnumerator SetTextBox(bool mode)
    {
        textFinished = false;

        if (!mode)
        {
            textBox.text = string.Empty;
        }
        else
        {
            textBox.text += "\n";
        }

        for (int i = 0; i < textList[index].Length; i++)
        {
            textBox.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }

        textFinished = true;
        index++;
    }
}
