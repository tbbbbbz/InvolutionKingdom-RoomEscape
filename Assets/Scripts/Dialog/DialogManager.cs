using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;
    private Queue<string> _sentences;

    public Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        animator.SetBool("Dialog_Open", true);
        nameText.text = dialog.CharacterName;
        _sentences.Clear();
        foreach (var sentence in dialog.sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) &&
            animator.GetBool("Dialog_Open"))
        {
            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        Debug.Log("Display Next Sentence");
        if (_sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(WriteSentence(sentence));
    }

    IEnumerator WriteSentence(string sentence)
    {
        dialogText.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    private void EndDialog()
    {
        animator.SetBool("Dialog_Open", false);
    }

    // Update is called once per frame

    public void clearAndEndDialog()
    {
        _sentences = new Queue<string>();
        DisplayNextSentence();
    }
}