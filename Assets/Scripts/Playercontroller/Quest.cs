using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Quest : MonoBehaviour
{
    public bool IsMissionDone = false;
    public bool DoIHaveAQuest = false;
    public DialougeTrigger Pr�st;
    public UnityEvent PossitivEvent;
    public UnityEvent NegativEvent;


    public void StartMission01()
    {
        DoIHaveAQuest =true;
    }
    public void NegativeAnswer()
    {
        print("Possitiv");
        Pr�st.enabled = false;
        NegativEvent.Invoke();   
    }

    public void PossitivAnswer()
    {
        print("Negativ");
        Pr�st.enabled = false;
        PossitivEvent.Invoke();
    }
}
