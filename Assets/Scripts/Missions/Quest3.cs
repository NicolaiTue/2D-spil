using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Quest3 : MonoBehaviour
{
    public UnityEvent CanPay;
    public UnityEvent CantPayUp;
    // Start is called before the first frame update
    
    public void Pay()
    {
        int money = GameManager.instance.GetMoney();
        if (money >= 5) 
        {
            CanPay.Invoke();
        }
        else
        {
            CantPayUp.Invoke();
        }
    }


}
