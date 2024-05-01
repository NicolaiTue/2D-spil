using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
public class SceneLoader : MonoBehaviour
{
    public float timeDelay;
    public float newTime;
    bool startTimer = false;
    public bool isThisAEndScene = false;
    public bool isThisCutsceneThatIsShit = false;



    private void Start()
    {
        newTime = Time.time + timeDelay;
        print("Detectet");
        //startTimer = true;
        
        
        StartCoroutine(Tester());
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator Tester()
    {
        if (isThisCutsceneThatIsShit)
        {
            Debug.LogError("Timer 1");
            yield return new WaitForSeconds(timeDelay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.LogError  ("Timer 2");
        }
        
    }
    private void Update()
    {
        Debug.LogError(Time.time + " / " + timeDelay);
        if (Time.time > newTime && !isThisAEndScene && !isThisCutsceneThatIsShit)
        {
            print("Detectet In Time");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Time.time > newTime && isThisAEndScene)
        {
            print("Detectet In Time");
            SceneManager.LoadScene(0);
        }
    }

}
