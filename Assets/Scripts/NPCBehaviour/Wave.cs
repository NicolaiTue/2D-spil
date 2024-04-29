using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wave : MonoBehaviour
{
    public Animator animator;
    public bool HasToWave;
    public GameObject Box;
    public UnityEvent events;
    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
        events.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("Talk");
        }
    }
    public void wave()
    {
        animator.SetTrigger("Wave");
    }
    public void endConvasasion() 
    {
        animator.SetTrigger("Idle");
        Destroy(gameObject.GetComponent<Wave>());
        Destroy(Box);
    }
}
