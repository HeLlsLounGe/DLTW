using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class Npc : MonoBehaviour
{
    [SerializeField] public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;
    [SerializeField] public float wordSpeed = 1f;
    public bool playerClose;
    bool keyPressed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                NoText();
            }else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
    }
    public void NextLine()
    {
        if (index > dialogue.Length -1f)
        {
            index++;
            dialogueText.text = " ";
            StartCoroutine(Typing());
        }
        else
        {
            NoText();
        }
    }
    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void NoText()
    {
        dialogueText.text = " ";
        index = 0;
        dialoguePanel.SetActive(false);
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
