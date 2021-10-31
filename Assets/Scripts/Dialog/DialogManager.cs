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

    void Awake()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        if (dialog != null)
        {
            animator.SetBool("Dialog_Open", true);
            nameText.text = dialog.CharacterName;
            _sentences.Clear();
            Action<string> action =
                new Action<string>(sentence => _sentences.Enqueue(sentence));
            Array.ForEach(dialog.sentences, action);
            DisplayNextSentence();
        }
        else
        {
            throw new ArgumentException("Dialog is null");
        }
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
            yield return new WaitForSeconds(0.02f);
        }
    }

    private void EndDialog()
    {
        animator.SetBool("Dialog_Open", false);
        _sentences.Clear();
    }

    // Update is called once per frame

    public void clearAndEndDialog()
    {
        _sentences.Clear();
        DisplayNextSentence();
    }
}