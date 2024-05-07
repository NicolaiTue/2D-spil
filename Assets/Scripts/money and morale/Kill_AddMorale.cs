using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_AddMorale : MonoBehaviour
{
    public int Moraleamount;
    private bool addedMorale = false; //  for at sikre, at morale kun tilf�jes �n gang

    private void OnDestroy()
    {
        if (!addedMorale)
        {
            // Tilf�j 20 moral, n�r objektet aktiveres f�rste gang
            GameManager.instance.AddMorale(10);
            addedMorale = true; // S�t addedMorale til sandt for at forhindre gentagen tilf�jelse af morale
            Debug.Log(10);
        }
    }
}
