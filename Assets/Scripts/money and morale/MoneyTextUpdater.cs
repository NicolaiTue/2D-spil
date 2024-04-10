using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyTextUpdater : MonoBehaviour
{
    public TextMeshProUGUI moneyText; // Reference til tekstobjektet, hvor pengene skal vises

    private void OnEnable()
    {
        // Lyt efter begivenheder, når dette script aktiveres
        GameManager.OnMoneyChanged += UpdateMoneyText;
    }

    private void OnDisable()
    {
        // Frakobl begivenheder, når dette script deaktiveres for at undgå hukommelseslækage
        GameManager.OnMoneyChanged -= UpdateMoneyText;
    }

    private void Start()
    {
        UpdateMoneyText(); // Opdaterer teksten ved start for at vise den aktuelle mængde penge
    }

    private void UpdateMoneyText()
    {
        // Hent den aktuelle mængde penge fra GameManager og opdater teksten
        moneyText.text = "Money: " + GameManager.instance.GetMoney().ToString();
    }
}
