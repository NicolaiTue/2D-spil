using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialougeTrigger : MonoBehaviour
{
    [SerializeField] private List<dialougeString> dialougeStrings = new List<dialougeString>();
    [SerializeField] private Transform NpcTransform;

    bool hasSpoken = false;

    [Header("NPC Selection")]
    public NPCManager nPCManager;
    public int NPCNumber;
    public bool IsNpcTraveller = false;
    public bool IsThisAMissionGiver = false;
    public bool IsDelivery = false;
    public bool Delivery2 = false;

    [Header("Travel")]
    public int WitchSceneIsTravel;

    [Header("Mission Selection & Settings")]
    
    public int NegativAnswer;
    public int PositivAnswer;
    
    public int DPAnswer;
    public int DNAnswer;
    


    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<DialougeManager>().DialougeStart(dialougeStrings, NpcTransform);
        hasSpoken=true;
        nPCManager.NameHolder = nPCManager.Names[NPCNumber];
        nPCManager.textureHolder = nPCManager.texures[NPCNumber];
        if (IsNpcTraveller)
        {
            other.gameObject.GetComponent<DialougeManager>().isTravellerManegerScript();
            other.gameObject.GetComponent<DialougeManager>().SetTravellerSceneNumber(WitchSceneIsTravel);
        }
        if (IsThisAMissionGiver)
        {
            other.gameObject.GetComponent<DialougeManager>().MissionAnswerReciver(PositivAnswer, NegativAnswer, IsThisAMissionGiver);
        }
        if (IsDelivery)
        {
            other.gameObject.GetComponent<DialougeManager>().DeliveryMissionReciver(DPAnswer, DNAnswer, IsDelivery);
        }
        if (Delivery2)
        {
            other.gameObject.GetComponent<DialougeManager>().Delivery2Reciver(Delivery2);
        }
        if (!IsDelivery && !Delivery2 && !IsThisAMissionGiver && !IsNpcTraveller)
        {
            other.gameObject.GetComponent<DialougeManager>().NormalNPCWithTalkReciver(true);
        }
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
