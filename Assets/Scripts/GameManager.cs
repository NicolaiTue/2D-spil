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

    // Method to save money and morale to PlayerPrefs
    private void SaveData()
    {
        PlayerPrefs.SetInt(moneyKey, money);
        PlayerPrefs.SetInt(moraleKey, morale);
        PlayerPrefs.Save();
    }

    // Method to load money and morale from PlayerPrefs
    private void LoadData()
    {
        money = PlayerPrefs.GetInt(moneyKey, 0);
        morale = PlayerPrefs.GetInt(moraleKey, 50); // Default morale value of 50
        

    }

    // Method to reset money and morale
    public void ResetData()
    {
        money = 50;
        morale = 50; // Reset morale to default value
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

    // Metoder til at få spillerens sundhedsoplysninger
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
