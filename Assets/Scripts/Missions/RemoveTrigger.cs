using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTrigger : MonoBehaviour
{
    public DialougeManager trigger;
    public DialougeTrigger TheTrigger;

    public void DestroyTrigger()
    {
        Destroy(trigger);
    }
    public void OnDestroyDialougeTrigger()
    {
        Destroy(TheTrigger);
    }
}
