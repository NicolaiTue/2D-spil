using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoraleScript : MonoBehaviour
{

    public int Moraleamount;
    private bool addedMorale = false; //  for at sikre, at morale kun tilf�jes �n gang

    private void OnEnable()
    {
        if (!addedMorale)
        {
            // Tilf�j 30 moral, n�r objektet aktiveres f�rste gang
            GameManager.instance.AddMorale(Moraleamount);
            addedMorale = true; // S�t addedMorale til sandt for at forhindre gentagen tilf�jelse af morale
        }
    }
}
