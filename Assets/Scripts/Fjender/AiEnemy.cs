using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiEnemy : MonoBehaviour
{
    public PlayerMove playerScript;

    public GameObject Player;
    public float speed;

    public string Attack;
    public string Se;

    // den vinkel den siger den ikke m� v�rer h�jere ned ellers retter den sig op igen
    public int tooSteepAngle = 12;

    public float attackdetectionRadius = 1f;
    public bool playerInRange = false;
    public float attackSpace = 0.5f;
    public float detectionRadius = 20f;
    private bool playerSeInRange = false;

    public float Damage = 10;
    public bool DMGAllow = false;

    private float d�Timeer = 5f;
    public string D�;
    public float Liv = 100;
    private float currentLiv;



    private int newz = 0;

    Animator anim;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentLiv = Liv;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSeInRange)
        {
            WalkAnimation();

            distance = Vector2.Distance(transform.position, Player.transform.position);
            Vector2 direction = Player.transform.position - transform.position;

            // Skift retningen baseret p� spillerens position
            Flip(direction.x);

            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
            if (transform.rotation.z > tooSteepAngle || transform.rotation.z < -1 * tooSteepAngle)
            {
                transform.rotation.z.Equals(newz);
            }
        }
       

        // k�rer funktionerne som g�r at den chekker om den attacke
        CheckForPlayer();
        UpdateAnimation();

        //Tjekker om Enemy har liv tilbage
        if (currentLiv <= 0)
        {
            DieAnaimation();
        }
    }

    void CheckForPlayer()
    {
        // Assume the player has a "Player" tag. Adjust as needed.
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        if (Player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);

            if (distanceToPlayer <= attackdetectionRadius)
            {
               playerInRange = true;

            }
            else
            {
                playerInRange = false;
            }
        }

        //playerScript.TakeDamageFromEnemy(Damage);

        if (Player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);

            // Den tjekker om den er inden for  se radisu og om den ikke er for t�t p� 
            if (attackSpace <= distanceToPlayer && distanceToPlayer <= detectionRadius)
            {
                playerSeInRange = true;
            }
            else
            {
                playerSeInRange = false;
            }
        }
    }
    
    public void HitPlayer(Collider2D collision)
    {
        playerScript.TakeDamageFromEnemy(Damage);
    }

    // g�r s� v�bnet kan g�re skade
    public void EnenableAttack()
    {
        DMGAllow = true;
    }
    // g�r s� v�bnet ikke kan g�re skade
    public void DisableAttack()
    {
        DMGAllow = false;
    }

    void UpdateAnimation()
    {
        if (playerInRange)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }


    void WalkAnimation()
    {
        if (playerSeInRange)
        {
            anim.SetBool("Se", true);
        }
        else
        {
            anim.SetBool("Se", false);
        }
    }

    void DieAnaimation()
    {
        anim.SetTrigger("D�");

        d�Timeer -= Time.deltaTime;

        if (d�Timeer <= 0f)
        {
            Destroy(gameObject);
        }


    }

    void Flip(float horizontalDirection)
    {
        // Skift retningen af fjendens sprite baseret p� spillerens position
        if ((horizontalDirection > 0 && !facingRight) || (horizontalDirection < 0 && facingRight))
        {
            facingRight = !facingRight;

            // Spejl fjendens sprite
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerWeapon")
        {
            TakeDamageFromPlayer(playerScript.DamageToEnemy);
        }
    }

    public void TakeDamageFromPlayer(float damage)
    {
        currentLiv -= damage;
    }

    private bool facingRight = false;
}
