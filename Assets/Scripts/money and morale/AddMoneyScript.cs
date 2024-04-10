using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoneyScript : MonoBehaviour
{
    public int Moneyamount;
    private bool addedMoney = false; //  for at sikre, at money kun tilf�jes �n gang

    private void OnEnable()
    {
        if (!addedMoney)
        {
            // Tilf�j Moneyamount til money, n�r objektet aktiveres f�rste gang
            GameManager.instance.AddMoney(Moneyamount);
            addedMoney = true; // S�t addedMoney til sandt for at forhindre gentagen tilf�jelse af morale
        }
    }
}
