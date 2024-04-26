using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float maxHealthIncrease = 20f; // Maksimal health for�gelse
    public int damageToEnemyIncrease = 5; // Skade til fjender for�gelse
    public  int healthToAdd = 10; // Health, der skal tilf�jes
    public int price;
    private bool SubtractMoney;
    public AudioClip buySound;
    private AudioSource audioSource;
    public  TextMeshProUGUI moneyText;

    private void Start()
    {
        // Hent lydkilden fra m�nten
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Hvis der ikke er en lydkilde, tilf�j en og indstil den
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

            // Afspil lyden for m�ntopsamling, hvis det ikke allerede er gjort
            if (!SubtractMoney && buySound != null)
            {
                AudioSource.PlayClipAtPoint(buySound, transform.position);
            }


            // �g spillerens maksimale sundhed
            player.MaxHealth += maxHealthIncrease;

            // �g skaden, som spilleren g�r mod fjender
            player.DamageToEnemy += damageToEnemyIncrease;

            // Tilf�j sundhed til spilleren
            player.AddHealth += healthToAdd;

            // Deaktiverer objektet, n�r power-up'en er blevet aktiveret
            gameObject.SetActive(false);
        
    }
}
