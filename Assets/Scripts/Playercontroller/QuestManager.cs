using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public bool isQuestDone = false;
    public bool isQuestFailed = false;
    public GameObject[] QuestScripts = new GameObject[] { };
    public int numberOfMission;
    public string nameOfMission;




    // used to call other scripts : QuestScripts[0].GetComponent("");



    // Update is called once per frame
    void Update()
    {
        
    }
}
