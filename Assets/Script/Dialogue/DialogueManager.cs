using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public DialogeSystem dialogueSystem;
    //private Queue<string> sentence;
    public Text nameText;
    public Text dialogueText;
    public Image character;
    public SoundManager speech;
    public GameObject nextButton;
    public float spawnTime;
    public bool ActivateOnStart = true;
    public float timeBtwChars = 0.1f;

    //spawn of object
    public GameObject spawnObject;
    private GameObject _spawnedObject;


    public void DisplayDialogue(DialogeSystem _dialogeSystem)
    {
        //nextbutton delay;
        nextButton.SetActive(false);
        if (ActivateOnStart)
        {
            ActivateDelayed();
        }

        //Spawn of object fuction
        
        //displaydialogue>>
        nameText.text = _dialogeSystem.nameChar;
        //dialogueText.text = _dialogeSystem.dialogueText;
        StopAllCoroutines();
        StartCoroutine(TypeSenctence(_dialogeSystem.dialogueText));
        character.sprite = _dialogeSystem.character;
        speech.PlaySound(_dialogeSystem.speech, 1f);
        //nextButton.nextButton = _dialogeSystem.nextButton;
    }

    private void AfterDelay()
    {
        nextButton.SetActive(true);
    }

    public void ActivateDelayed()
    {
        Invoke(nameof(AfterDelay), spawnTime);
    }

    public void ActivateDelayed(float customDelay)
    {
        Invoke(nameof(AfterDelay), customDelay);
    }

    IEnumerator TypeSenctence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(timeBtwChars);
        }
    }

    public void SpawnOfObject()
    {
        _spawnedObject = Instantiate(spawnObject);
    }

}
