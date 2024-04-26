using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float maxHealthIncrease = 20f; // Maksimal health forøgelse
    public int damageToEnemyIncrease = 5; // Skade til fjender forøgelse
    public  int healthToAdd = 10; // Health, der skal tilføjes
    public int price;
    private bool SubtractMoney;
    public AudioClip buySound;
    private AudioSource audioSource;
    public  TextMeshProUGUI moneyText;

    private void Start()
    {
        // Hent lydkilden fra mønten
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Hvis der ikke er en lydkilde, tilføj en og indstil den
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.clip = buySound;
        }

        moneyText.text = "Price: "+price.ToString();
    }

    public void Play()
    {
        PlayerMove player = GetComponent<PlayerMove>();

            if (!SubtractMoney)
            {
                GameManager.instance.SubtractMoney(price);
                SubtractMoney = true;
            }

            // Afspil lyden for møntopsamling, hvis det ikke allerede er gjort
            if (!SubtractMoney && buySound != null)
            {
                AudioSource.PlayClipAtPoint(buySound, transform.position);
            }


            // Øg spillerens maksimale sundhed
            player.MaxHealth += maxHealthIncrease;

            // Øg skaden, som spilleren gør mod fjender
            player.DamageToEnemy += damageToEnemyIncrease;

            // Tilføj sundhed til spilleren
            player.AddHealth += healthToAdd;

            // Deaktiverer objektet, når power-up'en er blevet aktiveret
            gameObject.SetActive(false);
        
    }
}
