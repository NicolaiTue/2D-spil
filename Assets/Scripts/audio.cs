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
            // Hvis der ikke er en lydkilde, tilf�j en og indstil den
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Indstil lyden til at loope og tilf�j lydklippet
        audioSource.loop = true;
        audioSource.clip = pickupSound;

        // Indstil lydstyrken baseret p� offentlig variabel
        audioSource.volume = volume;

        // Start afspilning
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Du kan tilf�je eventuelle andre logikker, der skal k�re l�bende, hvis n�dvendigt
    }
}
