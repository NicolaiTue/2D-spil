using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalConversasion : MonoBehaviour
{
    public DialougeTrigger dialougeTrigger;
    // Start is called before the first frame update
    public void EndConversasion()
    {
        Destroy(dialougeTrigger);
    }
}
