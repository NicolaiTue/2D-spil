using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Quest2Start : MonoBehaviour
{
    public bool missionIsStarted = false;
    public DialougeTrigger Barn;
    public GameObject BarnObject;
    public GameObject Barn2object;
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
        Destroy(BarnObject);
        Barn2object.SetActive(true);
    }
}
