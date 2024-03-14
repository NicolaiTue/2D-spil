using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerVåben : MonoBehaviour
{
    public PlayerMove playerMove;

    public string playerTag = "Player";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerMove.DMGAllow == true)
        {
            // Tjek om kollisionen er med objektet, der har fjendernes tag
            if (collision.CompareTag(playerTag))
            {
                // Kollision med fjende fundet
                playerMove.HitEnemy(collision);
                Debug.Log("Fjende hit!");
            }
        }


      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        
       
    }

    



}
