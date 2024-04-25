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


    private void Start()
    {
        
    }
    public void PossitivAnswer()
    {
        print("Possitiv");
        Destroy(Pr�st);
        PossitivEvent.Invoke();
    }
    public void NegativeAnswer()
    {
        print("Negativ");
        Destroy(Pr�st);
        NegativEvent.Invoke();   
    }

    
}
