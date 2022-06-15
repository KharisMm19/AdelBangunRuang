using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class DialogeSystem : ScriptableObject
{

    public string nameChar;
    public Sprite character;
    [TextArea(2, 5)]
    public string dialogueText;
    public AudioClip speech;
    public float WaitTime = 1f;
    public bool spawnObject;

}
