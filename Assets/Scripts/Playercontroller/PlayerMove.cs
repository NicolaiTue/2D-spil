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
    private float speed = 8f;
    public float setSpeed = 1;
    private float jumpingPower = 16f;
    public bool isFacingRight = true;

    public Vector3 localScale;

    //Physics and checks
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    // HP bar
    [SerializeField] Image HealthBar;
    public float MaxHealth = 100;
    public bool takeDamage = false;
    public float testDamage = 80;
    float currentHealth;

    private void Start()
    {
        animator = GetComponent<Animator>();

        //set health
        currentHealth = MaxHealth;
    }
    void Update()
    {
        //modtager input fra højre og venstre ved at tage input axis som bliver defineret i project settings
        horizontal = Input.GetAxisRaw("Horizontal");


        //giver speed værdien til animatoren så den kan lave animation når man bevæger sig.
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
        //køre flip funktionen
        Flip();
        CheckIfPlayerTakeDamage();
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    //laver en usnlig cicle for at tjekke om spilleren er på jorden. den tjekker på objectet den rør veds Layer.
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Flip()
    {
        //den tjekker om du gør til højre på x aksen eller venstre. 0 er midtpunktet. hvis du går til den ene eler den anden side flipper den.
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            localScale = transform.localScale;
            //minus gange minus giver plus. ved det koncept kan man skifte om tallet skal være positivt eller negativt, og roter spilleren på den givende akse i endten minus eller plus.
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

    


}
