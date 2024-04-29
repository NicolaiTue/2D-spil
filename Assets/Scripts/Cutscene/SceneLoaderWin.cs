using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoaderWin : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Start menu");
    }
}
