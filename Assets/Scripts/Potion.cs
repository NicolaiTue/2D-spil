using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public AudioClip pickupSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        // Tjek om der allerede er en AudioSource knyttet til objektet
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Hvis ikke, tilføj en ny AudioSource
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            // Sæt lydklippet for AudioSource
            audioSource.clip = pickupSound;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Tjek om kollisionen er med spilleren
        if (other.CompareTag("Player"))
        {
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);              
            }
            // Fjern potion fra scenen
            Destroy(gameObject);
        }

        // Hvis potions kolliderer med jorden
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Stop potions fald
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0f;
            }
        }
    }
}
