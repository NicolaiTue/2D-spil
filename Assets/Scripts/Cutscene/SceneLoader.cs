using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public float timeDelay;
    float newTime;
    bool startTimer = false;    



    void start()
    {
        CutsceneT();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void CutsceneT()
    {
        newTime = Time.time + timeDelay;
        startTimer = true;
        if (Time.time > newTime && startTimer)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
