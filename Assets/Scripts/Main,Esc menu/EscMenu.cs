using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    public GameObject escMenu;
    bool MenuActive = false;
    private void Start()
    {
        escMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Esc") && !MenuActive)
        {
            Freez();
        }
        else if (Input.GetButtonDown("Esc") && MenuActive)
        {           
            Unfreez();
        }
       
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Unfreez()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        escMenu.SetActive(false);
        Time.timeScale = 1f;
        MenuActive = false;
        
    }
    public void Freez()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        escMenu.SetActive(true);
        Time.timeScale = 0f;
        MenuActive = true;
        
    }
}
