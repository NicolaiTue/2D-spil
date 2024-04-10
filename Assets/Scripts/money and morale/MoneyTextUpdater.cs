using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyTextUpdater : MonoBehaviour
{
    public TextMeshProUGUI moneyText; // Reference til tekstobjektet, hvor pengene skal vises

    private void OnEnable()
    {
        // Lyt efter begivenheder, n�r dette script aktiveres
        GameManager.OnMoneyChanged += UpdateMoneyText;
    }

    private void OnDisable()
    {
        // Frakobl begivenheder, n�r dette script deaktiveres for at undg� hukommelsesl�kage
        GameManager.OnMoneyChanged -= UpdateMoneyText;
    }

    private void Start()
    {
        UpdateMoneyText(); // Opdaterer teksten ved start for at vise den aktuelle m�ngde penge
    }

    private void UpdateMoneyText()
    {
        // Hent den aktuelle m�ngde penge fra GameManager og opdater teksten
        moneyText.text = "Money: " + GameManager.instance.GetMoney().ToString();
    }
}
