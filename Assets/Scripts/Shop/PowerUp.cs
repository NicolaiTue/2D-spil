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
    public GameObject Player;

    private GameManager gameManager;

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
        gameManager = GameManager.instance;
    }

    public void Play()
    {
        if (gameManager.GetMoney() >= price)
        {
            gameManager.SubtractMoney(price);
            SubtractMoney = true;

            // Play buy sound
            if (buySound != null)
            {
                AudioSource.PlayClipAtPoint(buySound, transform.position);
            }

            // Øg spillerens maksimale sundhed
            Player.GetComponent<PlayerMove>().MaxHealth += maxHealthIncrease;

            // Øg skaden, som spilleren gør mod fjender
            Player.GetComponent<PlayerMove>().DamageToEnemy += damageToEnemyIncrease;

            // Tilføj sundhed til spilleren
            Player.GetComponent<PlayerMove>().AddHealth += healthToAdd;

            // Opdater GameManager-variablerne
            gameManager.UpdatePlayerStats(Player.GetComponent<PlayerMove>().MaxHealth,
                                          Player.GetComponent<PlayerMove>().DamageToEnemy,
                                          Player.GetComponent<PlayerMove>().AddHealth);

            // Deaktiverer objektet, når power-up'en er blevet aktiveret
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }
}
