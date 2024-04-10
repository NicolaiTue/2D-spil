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

    // Definition af en statisk begivenhed for at signalere, n�r pengem�ngden �ndres
    public delegate void MoneyChanged();
    public static event MoneyChanged OnMoneyChanged;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Beholder GameManager objekt n�t man loader en ny scene 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Loader moeny og morale fra  PlayerPrefs n�r spillet starter
        LoadData();
    }

    // metoden der tilf�jer money
    public void AddMoney(int amount)
    {
        money += amount;
        SaveData();
    }

    // metoden der tr�kker money fra
    public void SubtractMoney(int amount)
    {
        money -= amount;
        SaveData();
    }

    //  metoden der tilf�jer morale
    public void AddMorale(int amount)
    {
        morale += amount;
        SaveData();
    }

    // metoden der tr�kker morale fra
    public void SubtractMorale(int amount)
    {
        morale -= amount;
        SaveData();
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
        money = 0;
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
}
