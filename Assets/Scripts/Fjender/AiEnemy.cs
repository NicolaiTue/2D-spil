using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AiEnemy : MonoBehaviour
{
    public PlayerMove playerScript;

    public GameObject Player;
    public float speed;

    public string Attack;
    public string Se;

    // den vinkel den siger den ikke må værer højere ned ellers retter den sig op igen
    public int tooSteepAngle = 12;

    public float attackdetectionRadius = 1f;
    public bool playerInRange = false;
    public float attackSpace = 0.5f;
    public float detectionRadius = 20f;
    private bool playerSeInRange = false;

    public float Damage = 10;
    public bool DMGAllow = false;

    private float døTimeer = 5f;
    public string Dø;
    public float Liv = 100;
    private float currentLiv;
    bool canTakeDamage = false;
    [SerializeField] Image EHealthBar;
    Collider2D ECollider;

    public int minMoneyOnDeath = 0; // Minimum antal penge, fjenden kan give, når den dør
    public int maxMoneyOnDeath = 3; // Maksimum antal penge, fjenden kan give, når den dør

    private int newz = 0;

    Animator anim;

    private float distance;

    //lyd
    public AudioClip attackSound;
    private AudioSource audioSource;

    bool isDeathSoundPlaying = false;
    //død lyde
    public AudioClip DeathSound0;
    private AudioSource audioSource0;

    public AudioClip DeathSound1;
    private AudioSource audioSource1;

    public AudioClip DeathSound2;
    private AudioSource audioSource2;

    public AudioClip DeathSound3;
    private AudioSource audioSource3;

    public AudioClip DeathSound4;
    private AudioSource audioSource4;


    // Start is called before the first frame update
    void Start()
    {
        

        anim = GetComponent<Animator>();
        ECollider = GetComponent<Collider2D>();
        currentLiv = Liv;

        // Tjek om der allerede er en AudioSource knyttet til objektet
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Hvis ikke, tilføj en ny AudioSource
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            // Sæt lydklippet for AudioSource
            audioSource.clip = attackSound;
        }

        audioSource0 = GetComponent<AudioSource>();
        if (audioSource0 == null)
        {
            // Hvis ikke, tilføj en ny AudioSource
            audioSource0 = gameObject.AddComponent<AudioSource>();
            audioSource0.playOnAwake = false;
            // Sæt lydklippet for AudioSource
            audioSource0.clip = DeathSound0;
        }

        audioSource1 = GetComponent<AudioSource>();
        if (audioSource1 == null)
        {
            // Hvis ikke, tilføj en ny AudioSource
            audioSource1 = gameObject.AddComponent<AudioSource>();
            audioSource1.playOnAwake = false;
            // Sæt lydklippet for AudioSource
            audioSource1.clip = DeathSound1;
        }

        audioSource2 = GetComponent<AudioSource>();
        if (audioSource2 == null)
        {
            // Hvis ikke, tilføj en ny AudioSource
            audioSource2 = gameObject.AddComponent<AudioSource>();
            audioSource2.playOnAwake = false;
            // Sæt lydklippet for AudioSource
            audioSource2.clip = DeathSound2;
        }

        audioSource3 = GetComponent<AudioSource>();
        if (audioSource3 == null)
        {
            // Hvis ikke, tilføj en ny AudioSource
            audioSource3 = gameObject.AddComponent<AudioSource>();
            audioSource3.playOnAwake = false;
            // Sæt lydklippet for AudioSource
            audioSource3.clip = DeathSound3;
        }

        audioSource4 = GetComponent<AudioSource>();
        if (audioSource4 == null)
        {
            // Hvis ikke, tilføj en ny AudioSource
            audioSource4 = gameObject.AddComponent<AudioSource>();
            audioSource4.playOnAwake = false;
            // Sæt lydklippet for AudioSource
            audioSource4.clip = DeathSound4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSeInRange)
        {
            WalkAnimation();

            distance = Vector2.Distance(transform.position, Player.transform.position);
            Vector2 direction = Player.transform.position - transform.position;

            // Skift retningen baseret på spillerens position
            Flip(direction.x);

            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
            if (transform.rotation.z > tooSteepAngle || transform.rotation.z < -1 * tooSteepAngle)
            {
                transform.rotation.z.Equals(newz);
            }
        }
       

        // kører funktionerne som gør at den chekker om den attacke
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

            // Den tjekker om den er inden for  se radisu og om den ikke er for tæt på 
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

    // gør så våbnet kan gøre skade
    public void EnenableAttack()
    {
        DMGAllow = true;
    }
    // gør så våbnet ikke kan gøre skade
    public void DisableAttack()
    {
        DMGAllow = false;
    }

    public void AttackSound()
    {
        AudioSource.PlayClipAtPoint(attackSound, transform.position);
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
        string deadLayerName = "Dead";

        // Ændrer laget for parent objektet
        gameObject.layer = LayerMask.NameToLayer(deadLayerName);

        // Gennemgår alle child objekter og ændrer deres lag
        foreach (Transform child in transform)
        {
            // Ændrer laget for barnet
            child.gameObject.layer = LayerMask.NameToLayer(deadLayerName);

            // Hvis barnet har child objekter, gennemgå dem rekursivt
            if (child.childCount > 0)
            {
                ChangeLayer(child, deadLayerName);
            }
        }
               
        // Hvis lyden allerede afspilles, så afslut funktionen
        if (isDeathSoundPlaying)
        {
            return;
        }

        // Opret en liste af dødlyde
        AudioClip[] deathSounds = { DeathSound0, DeathSound1, DeathSound2, DeathSound3, DeathSound4 };

        // Vælg en tilfældig lyd fra listen
        int randomIndex = Random.Range(0, deathSounds.Length);
        AudioClip randomDeathSound = deathSounds[randomIndex];

        anim.SetTrigger("Dø");

        // Afspil den tilfældigt valgte lyd
        AudioSource.PlayClipAtPoint(randomDeathSound, transform.position);

        // Marker at lyden er begyndt at afspille
        isDeathSoundPlaying = true;
    }

    private void ChangeLayer(Transform parentTransform, string layerName)
    {
        // Gennemgår alle børneobjekter og ændrer deres lag
        foreach (Transform child in parentTransform)
        {
            // Ændrer laget for child
            child.gameObject.layer = LayerMask.NameToLayer(layerName);

            // Hvis barnet har child objekter, gennemgå dem rekursivt
            if (child.childCount > 0)
            {
                ChangeLayer(child, layerName);
            }
        }
    }

    void AfterDeathAnimation()
    {
        
        if (facingRight)
        {
            anim.SetTrigger("LiggerDødHøjre");
            // Spejl fjendens sprite
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

        }
        else if (!facingRight)
        {
            anim.SetTrigger("LiggerDødVenstre");

        }
        
        
    }
    void DestroyObject()
    {
               
        // Generer et tilfældigt antal penge mellem minMoneyOnDeath og maxMoneyOnDeath
        int moneyToGive = Random.Range(minMoneyOnDeath, maxMoneyOnDeath + 1); // maxMoneyOnDeath er eksklusivt, derfor +1

        // Tilføj det tilfældige antal penge til GameManager
        GameManager.instance.AddMoney(moneyToGive);

        Destroy(gameObject);
    }
    void SetDeathSpeed()
    {
        speed = 0;
        ECollider.enabled = false;
    }
    void Flip(float horizontalDirection)
    {
        // Skift retningen af fjendens sprite baseret på spillerens position
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
            Collider2D swordCollider = collision.GetComponent<Collider2D>();
            
                TakeDamageFromPlayer(playerScript.DamageToEnemy);
            swordCollider.enabled = false;
        }
    }

    public void TakeDamageFromPlayer(float damage)
    {
        currentLiv -= damage;
        EHealthBar.fillAmount = currentLiv / Liv;
    }

    private bool facingRight = false;
}
