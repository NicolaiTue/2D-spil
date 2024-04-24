using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void goToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void restartLevel()
    {
        
        int index;
        index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
        
    }

}
