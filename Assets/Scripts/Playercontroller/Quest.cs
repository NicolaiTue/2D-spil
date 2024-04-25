using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public bool IsMissionDone = false;
    public bool DoIHaveAQuest = false;
    public DialougeTrigger Præst;

    public void StartMission01()
    {
        DoIHaveAQuest =true;
    }
    public void NegativeAnswer()
    {
        
        Præst.enabled = false;
    }

    public void PossitivAnswer()
    {


        Præst.enabled = false;
    }
}
