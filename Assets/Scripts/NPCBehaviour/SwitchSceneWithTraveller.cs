using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneWithTraveller : MonoBehaviour
{
    [Header("Settings")]
    public int SceneIndex;
   public void Travel()
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
