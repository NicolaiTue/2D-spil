using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Quest2Start : MonoBehaviour
{
    public bool missionIsStarted = false;
    public DialougeTrigger Barn;
    public DialougeTrigger Barn2;
    public UnityEvent Deliver;
    public UnityEvent Refuse;


    public void RefuseMission()
    {
        print("RefusedMission");
        Destroy(Barn);
        Refuse.Invoke();
    }
    public void Delivery()
    {
        print("Acceptet Mision");
        Destroy(Barn);
        Barn2.enabled = true;
        Deliver.Invoke();
    }
}
