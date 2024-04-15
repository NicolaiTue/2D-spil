using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyReset : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.ResetData();
    }
}
