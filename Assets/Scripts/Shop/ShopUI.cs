using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject shopPanel; // Dette er panelet, som du vil aktivere/deaktivere

    private bool playerInRange = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Tjekker om shopPanelet er aktivt
            if (!shopPanel.activeSelf)
            {
                // Aktiverer shopPanelet, hvis det ikke allerede er aktivt
                shopPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                // Deaktiverer shopPanelet, hvis det allerede er aktivt
                shopPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
