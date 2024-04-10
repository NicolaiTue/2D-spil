using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private float textSpeed = 0.02f;

    [SerializeField] private bool PlayerSpeakingFirst;

    [SerializeField] private TextMeshProUGUI playerTextBubblesBubble;
    [SerializeField] private TextMeshProUGUI nPCTextBubbleBubble;

    [SerializeField] private string playerTextBubblesText;
    [SerializeField] private string nPCTextBubbleText;

    [SerializeField] GameObject playerContinueButton;
    [SerializeField] GameObject nPCContinueButton;

    int playerTextIndex;
    int npcTextIndex;

    private IEnumerator TypePlayerDialouge()
    {
        foreach(char letters in playerTextBubblesText[playerTextIndex].T())
        yield return new WaitForSeconds(textSpeed);
    }
}
