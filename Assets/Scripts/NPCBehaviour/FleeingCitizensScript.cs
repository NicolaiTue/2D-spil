using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeingCitizensScript : MonoBehaviour
{
    Animator animator;
    public GameObject[] NPC = new GameObject[5];
    public GameObject[] Wagons = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Flee()
    {
        animator.SetTrigger("Fleeing");
        for (int i = 0; i < 5; i++)
        {
            NPC[i].GetComponent<Animator>().SetTrigger("Walk");
        }
        for (int i = 0; i < Wagons.Length; i++)
        {
            Wagons[i].GetComponent<Animator>().SetTrigger("Drive");
        }
    }
    public void DestroyNpcs()
    {
        Destroy(gameObject);
    }
}
