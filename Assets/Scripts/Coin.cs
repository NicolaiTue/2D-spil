using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int moneyAmount = 30; // M�ngden af penge, der skal tilf�jes
    private bool hasAddedMoney = false; // For at sikre, at penge kun tilf�jes �n gang

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Tjek om kollisionen er med spilleren
        if (other.CompareTag("Player"))
        {
            // Tilf�j penge, hvis det ikke allerede er gjort
            if (!hasAddedMoney)
            {
                GameManager.instance.AddMoney(moneyAmount);
                hasAddedMoney = true; // S�t hasAddedMoney til sand for at forhindre gentagen tilf�jelse af penge
            }

            // Fjern m�nten fra scenen
            Destroy(gameObject);
        }

        // Hvis m�nten kolliderer med jorden
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Stop m�ntens fald
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0f;
            }
        }
    }
}
