using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    [Header("Switch Scene Settings")]
    public int SceneIndex;

    public void Switch()
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
