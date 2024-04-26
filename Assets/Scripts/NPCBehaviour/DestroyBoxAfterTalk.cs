using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoxAfterTalk : MonoBehaviour
{
    public GameObject Box;
    // Start is called before the first frame update
    public void Destroy()
    {
        Destroy(Box);
    }
}
