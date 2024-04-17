using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.Experimental.AI;

public class DialougeManager : MonoBehaviour
{
    [SerializeField] private GameObject dialougeParent;
    [SerializeField] private TMPro.TextMeshPro dialougeText;
    [SerializeField] private Button option1Button;
    [SerializeField] private Button option2Button;

    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private float turnSpeed = 2f;

    private List<dialougeString> dialougeList;

    [Header("Player")]
    public PlayerMove PlayerMove;
    private Transform playerCamera;

    int currentDialougeIndex = 0;

    private void Start()
    {
        dialougeParent.SetActive(false);
        playerCamera = Camera.main.transform;
    }

    public void DialougeStart(List<dialougeString> textToPrint, Transform NPC)
    {
        dialougeParent.SetActive(true);
        PlayerMove.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartCoroutine(TurnCameraTowardsNPC(NPC));

        dialougeList = textToPrint;
        currentDialougeIndex = 0;

        DisableButtons();

        StartCoroutine(PrintDialouge());
    }
    void DisableButtons()
    {
        option1Button.interactable = false;
        option2Button.interactable = false;

        option1Button.GetComponentInChildren<TMPro.TextMeshPro>().text = "No Option";
        option2Button.GetComponentInChildren<TMPro.TextMeshPro>().text = "No Option";
    }
    private IEnumerator TurnCameraTowardsNPC(Transform NPC)
    {
        Quaternion startRotation = playerCamera.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(NPC.position - playerCamera.position);

        float elapseTime = 0f;
        while (elapseTime < 1f) 
        {
            playerCamera.rotation = Quaternion.Slerp(startRotation, targetRotation, elapseTime);
            elapseTime += Time.deltaTime * turnSpeed;
            yield return null;
        }
        playerCamera.rotation = targetRotation;
    }

    private bool optionSelected = false;

    private IEnumerator PrintDialouge()
    {
        while (currentDialougeIndex < dialougeList.Count)
        {
            dialougeString line = dialougeList[currentDialougeIndex];

            line.startDialougeEvent?.Invoke();

            if (line.isQuestion)
            {
                yield return StartCoroutine(typeText(line.text));
                option1Button.interactable = true;
                option2Button.interactable = true;

                option1Button.GetComponentInChildren<TMPro.TextMeshPro>().text = line.AnswerOption01;
                option2Button.GetComponentInChildren<TMPro.TextMeshPro>().text = line.AnswerOption02;

                option1Button.onClick.AddListener(() => HandleOptionSelected(line.option1IndexJump));
                option2Button.onClick.AddListener(() => HandleOptionSelected(line.option2IndexJump));

                yield return new WaitUntil(() => optionSelected);
            }
            else
            {
                yield return StartCoroutine(typeText(line.text));

            }
            line.startDialougeEvent?.Invoke();

            optionSelected = false;
        }
        dialougeStop();
    }
    void HandleOptionSelected(int indexJump)
    {
        optionSelected = true;
        DisableButtons();

        currentDialougeIndex = indexJump;
    }

    private IEnumerator typeText(string text)
    {
        dialougeText.text = "";
        foreach (char letter in text.ToCharArray()) 
        {
            dialougeText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        if (!dialougeList[currentDialougeIndex].isQuestion)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }
        if (dialougeList[currentDialougeIndex].isEnded)
            dialougeStop();

        currentDialougeIndex++;
    }

    void dialougeStop()
    {
        StopAllCoroutines();
        dialougeText.text = "";
        dialougeParent.SetActive(false);
        PlayerMove.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
