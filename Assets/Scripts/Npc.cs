using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class Npc : MonoBehaviour
{
    [SerializeField] public GameObject EToTalk;
    [SerializeField] public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;
    [SerializeField] public float wordSpeed = 1f;
    [SerializeField] public GameObject ContButton;
    [SerializeField] float timerDelay;
    public bool playerClose;
    bool keyPressed;
    float timer = 0f;
    bool PressTalk = false;

    void Update()
    {
        if (playerClose)
        {
            PressTalk = true;
        }else
        {
            PressTalk = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && playerClose)
        {
            if (dialoguePanel.activeInHierarchy && timer <= timerDelay)
            {
                NoText();
            }else
            {
                dialogueText.text = " ";
                dialoguePanel.SetActive(true);
                dialogueText.gameObject.SetActive(true);
                NextLine();
                timer += Time.deltaTime;
            }
        }
        if (dialogueText.text == dialogue[index])
        {
            if (dialoguePanel.activeInHierarchy)
            {
                NoText();
                ContButton.SetActive(false);
            }else
            {
                ContButton.SetActive(true);
            }
        }
        if (PressTalk)
        {
            EToTalk.SetActive(true);
        }else
        {
            EToTalk.SetActive(false);
        }
    }
    public void NextLine()
    {
        ContButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = " ";
            StartCoroutine(Typing());
        }
        else
        {
            index = 1;
            dialogueText.text = " ";
            StartCoroutine(Typing());
        }
    }
    IEnumerator Typing()
    {
        ContButton.SetActive(false);
        foreach (char letter in dialogue[index].ToCharArray())
        {
            if (playerClose)
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
            }else
            {
                NoText();
            }
        }
        ContButton.SetActive(true);
    }
    public void NoText()
    {
        dialogueText.text = " ";
        dialoguePanel.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        ContButton.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerClose = false;
            NoText();
        }
    }
}
