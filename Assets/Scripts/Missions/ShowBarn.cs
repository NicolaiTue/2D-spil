using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBarn : MonoBehaviour
{
    public GameObject Barn;
    public float timeDelay;
    float newTime;
    bool startTimer = false;
    public void ShowChild()
    {
        newTime = Time.time + timeDelay;
        startTimer = true;
        if (Time.time > newTime && startTimer)
        {
            Barn.SetActive(true);
        }
        
    }
}
