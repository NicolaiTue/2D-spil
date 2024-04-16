using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialougeTrigger : MonoBehaviour
{
    [SerializeField] private List<dialougeString> dialougeStrings = new List<dialougeString>();
    [SerializeField] private Transform NpcTransform;

    bool hasSpoken = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<DialougeManager>().DialougeStart(dialougeStrings, NpcTransform);
        hasSpoken=true;
    }
}

[System.Serializable]
public class dialougeString
{
    public string text; // viser hvad npc'en skal sige.
    public bool isEnded; // viser hvis sidste linje er kørt.

    [Header("Branch")]
    public bool isQuestion;
    public string AnswerOption01;
    public string AnswerOption02;
    public int option1IndexJump;
    public int option2IndexJump;

    [Header("Trigger events")]
    public UnityEvent startDialougeEvent;
    public UnityEvent endDialougeEvent;

}
