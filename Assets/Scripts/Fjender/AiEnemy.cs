using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnemy : MonoBehaviour
{

    public GameObject Player;
    public float speed;

    public string Attack;
    public string Se;
    public int tooSteepAngle = 12;

    public float attackdetectionRadius = 1f;
    private bool playerInRange = false;
    public float attackSpace = 0.5f;
    public float detectionRadius = 20f;
    private bool playerSeInRange = false;

    private int newz = 0;

    Animator anim;


    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerSeInRange)
        {
            WalkAnimation();

            distance = Vector2.Distance(transform.position, Player.transform.position);
            Vector2 direction = Player.transform.forward - transform.forward;

            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
            if(transform.rotation.z > tooSteepAngle || transform.rotation.z < -1 * tooSteepAngle)
            {
                transform.rotation.z.Equals(newz);
            }

            
        }
        else
        {
            anim.SetBool("Se", false);
        }



        // kører funktionerne som gør at den chekker om den attacke
        CheckForPlayer();
        UpdateAnimation();
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

        if (Player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);
            // Den tjekker om den er inden for den se radisu og om den ikke er for tæt på 
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
}
