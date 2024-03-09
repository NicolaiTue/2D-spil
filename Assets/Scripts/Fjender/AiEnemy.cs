using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnemy : MonoBehaviour
{

    public GameObject Player;
    public float speed;

    public string kan_angribe;
    public string kan_ikke_angribe;
    public string kan_ikke_se;
    public string kan_se;

    public float detectionRadius = 5f;
    private bool playerInRange = false;

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
        distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.forward - transform.forward;

        transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);


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

            if (distanceToPlayer <= detectionRadius)
            {
                playerInRange = true;
            }
            else
            {
                playerInRange = false;
            }
        }
    }


    void UpdateAnimation()
    {
        
        if (playerInRange)
        {
            anim.SetTrigger(kan_angribe);
        }
        else
        {
            anim.SetTrigger(kan_ikke_angribe);
        }
    }

}
