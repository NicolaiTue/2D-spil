using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Money and morale variables
    private int money;
    private int morale;

    // Keys for PlayerPrefs
    private const string moneyKey = "Money";
    private const string moraleKey = "Morale";
    private const string maxHealthKey = "MaxHealth";
    private const string damageToEnemyKey = "DamageToEnemy";
    private const string addHealthKey = "AddHealth";


    // Player stats
    private float playerMaxHealth = 100;
    private int playerDamageToEnemy = 15;
    private int playerAddHealth = 25;

    // Definition af en statisk begivenhed for at signalere, når pengemængden ændres
    public delegate void MoneyChanged();
    public static event MoneyChanged OnMoneyChanged;

    void Awake()
    {        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Loader moeny og morale fra  PlayerPrefs når spillet starter
        LoadData();
    }

    // metoden der tilføjer money
    public void AddMoney(int amount)
    {
        money += amount;
        SaveData();
        OnMoneyChanged?.Invoke(); // Udløser OnMoneyChanged-begivenheden
    }

    // metoden der trækker money fra
    public void SubtractMoney(int amount)
    {
        money -= amount;
        SaveData();
        OnMoneyChanged?.Invoke(); // Udløser OnMoneyChanged-begivenheden
    }

    //  metoden der tilføjer morale
    public void AddMorale(int amount)
    {
        morale += amount;
        SaveData();
        OnMoneyChanged?.Invoke(); // Udløser OnMoneyChanged-begivenheden
    }

    // metoden der trækker morale fra
    public void SubtractMorale(int amount)
    {
        morale -= amount;
        SaveData();
        OnMoneyChanged?.Invoke(); // Udløser OnMoneyChanged-begivenheden
    }

    // Metode til at gemme  money, morale, maxHealth, damageToEnemy og addHealth til PlayerPrefs
    private void SaveData()
    {
        PlayerPrefs.SetInt(moneyKey, money);
        PlayerPrefs.SetInt(moraleKey, morale);

        PlayerPrefs.SetFloat(maxHealthKey, playerMaxHealth);
        PlayerPrefs.SetInt(damageToEnemyKey, playerDamageToEnemy);
        PlayerPrefs.SetInt(addHealthKey, playerAddHealth);

        PlayerPrefs.Save();
    }

   
    private void LoadData()
    {
        money = PlayerPrefs.GetInt(moneyKey, 0);
        morale = PlayerPrefs.GetInt(moraleKey, 0); 
        

    }

    // Method to reset money and morale
    public void ResetData()
    {
        money = 0;
        morale = 0;
        playerMaxHealth = 100;
        playerDamageToEnemy = 15;
        playerAddHealth = 25;

         SaveData();
    }

    // Getter methods for money and morale
    public int GetMoney()
    {
        return money;
    }

    public int GetMorale()
    {
        return morale;
    }

    public void UpdatePlayerStats(float maxHealth, int damageToEnemy, int addHealth)
    {
        playerMaxHealth = maxHealth;
        playerDamageToEnemy = damageToEnemy;
        playerAddHealth = addHealth;
    }

    // Metoder til at få spillerens hp oplysninger
    public float GetPlayerMaxHealth()
    {
        return playerMaxHealth;
    }

    public int GetPlayerDamageToEnemy()
    {
        return playerDamageToEnemy;
    }

    public int GetPlayerAddHealth()
    {
        return playerAddHealth;
    }
}
