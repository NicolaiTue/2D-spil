using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int moneyAmount = 30; // Mængden af penge, der skal tilføjes
    public AudioClip pickupSound; // Lyden, der skal afspilles ved møntopsamling
    private bool hasAddedMoney = false; // For at sikre, at penge kun tilføjes én gang
    private AudioSource audioSource; // Lydkilden

    private void Start()
    {
        // Hent lydkilden fra mønten
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Hvis der ikke er en lydkilde, tilføj en og indstil den
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
            // Afspil lyden for møntopsamling, hvis det ikke allerede er gjort
            if (!hasAddedMoney && pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            // Tilføj penge, hvis det ikke allerede er gjort
            if (!hasAddedMoney)
            {
                GameManager.instance.AddMoney(moneyAmount);
                hasAddedMoney = true; // Sæt hasAddedMoney til sand for at forhindre gentagen tilføjelse af penge
            }

            // Fjern mønten fra scenen
            Destroy(gameObject);
        }

        // Hvis mønten kolliderer med jorden
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Stop møntens fald
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0f;
            }
        }
    }
}
