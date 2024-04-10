using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoneyScript : MonoBehaviour
{
    public int Moneyamount;
    private bool addedMoney = false; //  for at sikre, at money kun tilføjes én gang

    private void OnEnable()
    {
        if (!addedMoney)
        {
            // Tilføj Moneyamount til money, når objektet aktiveres første gang
            GameManager.instance.AddMoney(Moneyamount);
            addedMoney = true; // Sæt addedMoney til sandt for at forhindre gentagen tilføjelse af morale
        }
    }
}
