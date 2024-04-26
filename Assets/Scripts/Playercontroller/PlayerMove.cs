using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    //movements
    private float horizontal;
    public float speed = 8f;
    public float setSpeed = 1;
    private float jumpingPower = 16f;
    public bool isFacingRight = true;

    public Vector3 localScale;

    //Physics and checks
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    bool isInMenu = false;
    public bool canTalkToQuestGiver = false;
    

    public float skade = 10f;
    [Header("Health setting")]
    // HP bar
    [SerializeField] Image HealthBar;
    public float MaxHealth = 100;
    public bool takeDamage = false;
    public float testDamage = 80;
    public float currentHealth;

    public int AddHealth = 25;
    [Header("Damage To Enemy")]
    //DamageToEnemy
    public int DamageToEnemy = 30;
    [Header("Script Import")]
    // script import
    public PlayerV�ben v�ben;
    [Header("Sounds")]
    //lyd
    private AudioSource audioSource; // Lydkilden
    public AudioClip attackSound; // Lyden, der skal afspilles n�r man sl�r
    [Header("DeathScreen")]
    public GameObject deathScreen;



    private void Start()
    {
        Time.timeScale = 1f;
        animator = GetComponent<Animator>();

        //set health
        currentHealth = MaxHealth;

        // Hent lydkilden n�r man sl�r
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Hvis der ikke er en lydkilde, tilf�j en og indstil den
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.clip = attackSound;
        }
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //modtager input fra h�jre og venstre ved at tage input axis som bliver defineret i project settings
        horizontal = Input.GetAxisRaw("Horizontal");


        //giver speed v�rdien til animatoren s� den kan lave animation n�r man bev�ger sig.
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("JumpHeight", Mathf .Abs(rb.velocity.y));

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        //k�re flip funktionen
        Flip();
        CheckIfPlayerTakeDamage();
        isInAMenu();
        attack();
        checkIfDead();


    }
    //Check om man er i n�rheden af npc
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            canTalkToQuestGiver = true;
            
            print("Can talk with Jeff");
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            canTalkToQuestGiver = false;
            print("Can NOT talk with Jeff");
            

        }

        if (collision.gameObject.CompareTag("HPbost"))
        {
            // Add xx HP to currentHealth
            currentHealth += AddHealth;
            // Make sure currentHealth doesn't exceed MaxHealth
            currentHealth = Mathf.Min(currentHealth, MaxHealth);
            // Update the HealthBar
            HealthBar.fillAmount = currentHealth / MaxHealth;

            // Optionally, disable the health object after player collides with it
            //collision.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    //laver en usnlig cicle for at tjekke om spilleren er p� jorden. den tjekker p� objectet den r�r veds Layer.
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Flip()
    {
        //den tjekker om du g�r til h�jre p� x aksen eller venstre. 0 er midtpunktet. hvis du g�r til den ene eler den anden side flipper den.
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            localScale = transform.localScale;
            //minus gange minus giver plus. ved det koncept kan man skifte om tallet skal v�re positivt eller negativt, og roter spilleren p� den givende akse i endten minus eller plus.
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void TakeDamageFromEnemy(float damage)
    {
        currentHealth -= damage;
        print(currentHealth);
        HealthBar.fillAmount = currentHealth / MaxHealth;
    }

    void CheckIfPlayerTakeDamage()
    {
        if (takeDamage)
        {

            TakeDamage();
            takeDamage = false;
        }
    }
    void TakeDamage()
    {
        
        currentHealth -= testDamage;
        print(currentHealth);
        HealthBar.fillAmount = currentHealth/100f;
    }

    void attack()
    {
        if (Input.GetButtonDown("LeftClick") && !isInMenu)
        {
            print("you have attacked");
            animator.SetBool("Attack", true);
            
        }
    }
    void sendAttackInfo()
    {
        AudioSource.PlayClipAtPoint(attackSound, transform.position);
        v�ben.Attack();
        print("v�bnet er d�dligt");
        

    }
    void disableAttackAnimation()
    {
        animator.SetBool("Attack", false);
        v�ben.finishedAttack();
        print("v�bnet er ikke d�dligt");
    }
    void isInAMenu()
    {
        if (Input.GetButtonDown("Esc") && !isInMenu)
        {
            Cursor.lockState = CursorLockMode.None;
            print("menu Opened");
            isInMenu = true;
        }
        else if (Input.GetButtonDown("Esc") && isInMenu)
        {
            isInMenu = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    void checkIfDead()
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 0f;
            deathScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;

        }
    }
   


}
