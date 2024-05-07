using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusMorale : MonoBehaviour
{

    public int Moraleamount;
    private bool addedMorale = false; //  for at sikre, at morale kun tilføjes én gang

    private void OnDestroy()
    {
        if (!addedMorale)
        {
            // Tilføj 20 moral, når objektet aktiveres første gang
            GameManager.instance.SubtractMorale(Moraleamount);
            addedMorale = true; // Sæt addedMorale til sandt for at forhindre gentagen tilføjelse af morale
            Debug.Log("-"+Moraleamount);
        }
    }
}
