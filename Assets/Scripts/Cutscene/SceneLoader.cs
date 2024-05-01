using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public float timeDelay;
    float newTime;
    bool startTimer = false;



    private void Start()
    {
        newTime = Time.time + timeDelay;
        print("Detectet");
        //startTimer = true;
        
        CutsceneT();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void CutsceneT()
    {
        
    }
    private void Update()
    {
        if (Time.time > newTime)
        {
            print("Detectet In Time");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
