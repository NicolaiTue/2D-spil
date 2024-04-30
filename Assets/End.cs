using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        // Find GameManager i scenen
        gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Tjek om kollideret objekt er spilleren
        if (other.CompareTag("Player"))
        {
            // Tjek spillerens morale
            int morale = gameManager.GetMorale();

            // Skift scene baseret på moraleværdien
            if (morale >= 80)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Skift til næste scene
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); // Skift til scenen efter den næste
            }
        }
    }
}
