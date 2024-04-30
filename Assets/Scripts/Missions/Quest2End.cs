using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Quest2End : MonoBehaviour
{
    public DialougeTrigger Barn2;
    public UnityEvent FinishMission;
    public UnityEvent CantPayUp;
    public void Delivery()
    {
        int money = GameManager.instance.GetMoney();
        if (money >= 25) 
        {
            print("Finished Mission 2");
            Destroy(Barn2);
            FinishMission.Invoke();
        }
        else
        {
            CantPayUp.Invoke();
        }
        
    }
}
