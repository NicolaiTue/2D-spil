using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Quest : MonoBehaviour
{
    public bool IsMissionDone = false;
    public bool DoIHaveAQuest = false;
    public DialougeTrigger Præst;
    public UnityEvent PossitivEvent;
    public UnityEvent NegativEvent;
    public UnityEvent CantPayUp;


    private void Start()
    {
        
    }
    public void PossitivAnswer()
    {
        print("Possitiv");
        Destroy(Præst);
        int coins = GameManager.instance.GetMoney();
        if (coins > 10)
        {
            PossitivEvent.Invoke();
        }
        else
        {
            CantPayUp.Invoke();
        }

    }
    public void NegativeAnswer()
    {
        print("Negativ");
        Destroy(Præst);
        NegativEvent.Invoke();   
    }

    
}
