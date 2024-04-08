using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WhiteIdlePriest : MonoBehaviour
{
    Animator anim;
    public bool IsPriestWhite;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPriestWhite)
        {
            anim.SetBool("IdleWhiteBool", true);
        }
    }
}
