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
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Esc") && !MenuActive)
        {
            escMenu.SetActive(true);
            MenuActive = true;
            Freez();
        }
        else if (Input.GetButtonDown("Esc") && MenuActive)
        {
            escMenu.SetActive(false);
            MenuActive = false;
            Unfreez();
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Unfreez()
    {
        Time.timeScale = 1f;
    }
    public void Freez()
    {
        Time.timeScale = 0f;
    }
}
