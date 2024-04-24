using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip pickupSound;
    private AudioSource audioSource;
    public float volume = 1.0f; // Initial lydstyrke, kan justeres fra editoren

    // Start is called before the first frame update
    void Start()
    {
        // Hent lydkilden fra gameobject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Hvis der ikke er en lydkilde, tilføj en og indstil den
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Indstil lyden til at loope og tilføj lydklippet
        audioSource.loop = true;
        audioSource.clip = pickupSound;

        // Indstil lydstyrken baseret på offentlig variabel
        audioSource.volume = volume;

        // Start afspilning
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Du kan tilføje eventuelle andre logikker, der skal køre løbende, hvis nødvendigt
    }
}
