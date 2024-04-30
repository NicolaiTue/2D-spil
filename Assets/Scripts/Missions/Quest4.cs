using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Quest4 : MonoBehaviour
{
    public UnityEvent PayUp;
    public UnityEvent CantPayUp;
    

    public void Pay()
    {
        int money = GameManager.instance.GetMoney();
        if (money>= 10)
        {
            PayUp.Invoke();
        }
        else
        {
            CantPayUp.Invoke();
        }
    }
}
