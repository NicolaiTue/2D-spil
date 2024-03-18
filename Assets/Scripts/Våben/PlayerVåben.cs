using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerVåben : MonoBehaviour
{
    public PlayerMove playerMove;

    public string TargetTag = "Enemy";
    Collider2D swordCollider;
    
    private void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        swordCollider.enabled = false;
    }

    private void Update()
    {
        
        
            
        
    }
    public void Attack()
    {
        swordCollider.enabled = true;
    }
    public void finishedAttack()
    {
        swordCollider.enabled = false;
    }
}
