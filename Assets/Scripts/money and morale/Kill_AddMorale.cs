using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_AddMorale : MonoBehaviour
{
    public int Moraleamount;
    private bool addedMorale = false; //  for at sikre, at morale kun tilføjes én gang

    private void OnDestroy()
    {
        if (!addedMorale)
        {
            // Tilføj 20 moral, når objektet aktiveres første gang
            GameManager.instance.AddMorale(10);
            addedMorale = true; // Sæt addedMorale til sandt for at forhindre gentagen tilføjelse af morale
            Debug.Log(10);
        }
    }
}
