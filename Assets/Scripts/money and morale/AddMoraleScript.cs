using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoraleScript : MonoBehaviour
{

    public int Moraleamount;
    private bool addedMorale = false; //  for at sikre, at morale kun tilføjes én gang

    private void OnEnable()
    {
        if (!addedMorale)
        {
            // Tilføj 30 moral, når objektet aktiveres første gang
            GameManager.instance.AddMorale(Moraleamount);
            addedMorale = true; // Sæt addedMorale til sandt for at forhindre gentagen tilføjelse af morale
        }
    }
}
