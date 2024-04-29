using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Våben : MonoBehaviour
{
    private AiEnemy aienemy;

    public string playerTag = "Player";

    private void Start()
    {
        aienemy = GetComponent<AiEnemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (aienemy.DMGAllow == true)
        {
            // Tjek om kollisionen er med objektet, der har spillerens tag
            if (collision.CompareTag(playerTag))
            {
                // Kollision med spilleren fundet
                aienemy.HitPlayer(collision);
                Debug.Log("Player hit!");
            }
        }


      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        
       
    }

    



}
