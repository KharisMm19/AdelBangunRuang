using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueNext : MonoBehaviour
{
    [SerializeField]
    private DialogeSystem[] scriptabeleObject;
    // [SerializeField]
    // private SpawnObject[] spawnObjects;
    [SerializeField]
    private DialogueManager dialogueManager;
    private DialogeSystem dialogeSystem;
    private int currentIndex;

    private void Awake()
    {
        //dialogueManager.DisplayDialogue((DialogeSystem)scriptabeleObject[0]);
        changeScriptableObject(0);
    }

    public void changeScriptableObject(int _change)
    {
        currentIndex += _change;

        if (currentIndex < 0)
        {
            currentIndex = scriptabeleObject.Length - 1;
            //currentIndex = spawnObjects.Length - 1;
        }
        else if (currentIndex > scriptabeleObject.Length - 1)
        {
            //Pindah Scene
           
            if (scriptabeleObject[currentIndex - 1].spawnObject == true)
            {
                dialogueManager.SpawnOfObject();
            }else{
                 Debug.Log("Pindah scene");
                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
        else if (dialogueManager != null)
        {
            dialogueManager.DisplayDialogue((DialogeSystem)scriptabeleObject[currentIndex]);
            //dialogueManager.StopSound((DialogeSystem)scriptabeleObject[currentIndex - 1]); 
            //wait();          
        }
    }

    // void wait()
    // {
    //     float currentTime = 0f;
    //     while (currentTime < dialogeSystem.WaitTime)
    //     {
    //         currentTime += 1f;
    //         if (currentTime == dialogeSystem.WaitTime)
    //         {
    //             dialogueManager.nextButton.SetActive(true);
    //         }
    //     }

    // }
}
