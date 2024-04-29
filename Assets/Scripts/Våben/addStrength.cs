using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addStrength : MonoBehaviour
{
    public int strengthAmount;
    private bool addedStrength = false; //  for at sikre, at damage kun tilf�jes �n gang
    private GameManager gameManager;
    public PlayerMove move;
    public DialougeTrigger trigger;
    private void Start()
    {
        gameManager = GameManager.instance;
        
    }
    
    public void AddStrength()
    {
        // Tilf�j Damageamount til spiller, n�r objektet kaldes
        move.DamageToEnemy += strengthAmount;
        gameManager.UpdatePlayerStats(move.MaxHealth,
                                      move.DamageToEnemy,
                                      move.AddHealth);
    }
    public void removeTrigger()
    {
        Destroy(trigger);
    }
}
