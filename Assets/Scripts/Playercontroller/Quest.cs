using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public bool IsMissionDone = false;
    public bool DoIHaveAQuest = false;
    public DialougeTrigger Pr�st;

    public void StartMission01()
    {
        DoIHaveAQuest =true;
    }
    public void NegativeAnswer()
    {
        
        Pr�st.enabled = false;
    }

    public void PossitivAnswer()
    {


        Pr�st.enabled = false;
    }
}
