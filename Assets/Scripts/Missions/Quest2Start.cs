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
    public float timeDelay;
    float newTime;
    bool startTimer = false;


    public void RefuseMission()
    {
        print("RefusedMission");
        Destroy(Barn);
    }
    public void Delivery()
    {
        print("Acceptet Mision");
        newTime = Time.time + timeDelay;
        startTimer = true;
        Destroy(Barn);



    }
    private void Update()
    {
        
        if (Time.time > newTime && startTimer)
        {

            Barn2object.SetActive(true);
            Destroy(BarnObject);
        }
    }
}
