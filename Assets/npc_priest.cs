using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_priest : MonoBehaviour
{

    public string Prist_dis;
    public float activationDistance = 5f; // Afstand, hvor "Prist_dis" skal aktiveres

    private Animator anim; // Antager, at du har en reference til din Animator

    // Start is called before the first frame update
    void Start()
    {
        bool bval =ConversationManager.Instance.GetBool("BoolName")
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayer();
    }

    void CheckForPlayer()
    {
        // Antager, at spilleren har en "Player" tag. Juster efter behov.
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= activationDistance)
            {
                bval.SetBool("Prist_dis;", true);
            }
            else
            {
                // Deaktiver Prist_dis
                // Eksempel: GetComponent<Prist_dis>().Deactivate();
                Debug.Log("Player out of activation distance.");
            }
        }
    }

    
