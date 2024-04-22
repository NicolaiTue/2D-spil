using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int moneyAmount = 30; // M�ngden af penge, der skal tilf�jes
    public AudioClip pickupSound; // Lyden, der skal afspilles ved m�ntopsamling
    private bool hasAddedMoney = false; // For at sikre, at penge kun tilf�jes �n gang
    private AudioSource audioSource; // Lydkilden

    private void Start()
    {
        // Hent lydkilden fra m�nten
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Hvis der ikke er en lydkilde, tilf�j en og indstil den
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.clip = pickupSound;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Tjek om kollisionen er med spilleren
        if (other.CompareTag("Player"))
        {
            // Afspil lyden for m�ntopsamling, hvis det ikke allerede er gjort
            if (!hasAddedMoney && pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

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
