using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.LucidEditor;

namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class Chest : MonoBehaviour
    {
        [FoldoutGroup("Reference")]
        public Animator animator;

        [FoldoutGroup("Runtime")]
        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                animator.SetBool("IsOpened", isOpened);
            }
        }
        private bool isOpened;

        // Radius for detecting player proximity
        [FoldoutGroup("Runtime")]
        public float interactRadius = 2f;

        // Reference to the player GameObject
        private GameObject player;

        private void Start()
        {
            // Find the player GameObject by tag
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            // Check if the player is close and presses the interact key
            if (Vector2.Distance(transform.position, player.transform.position) <= interactRadius && Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }

        // Function to handle the interaction with the chest
        private void Interact()
        {
            // Toggle the state of the chest
            IsOpened = !IsOpened;
        }

        [FoldoutGroup("Runtime"),Button("Open"), HorizontalGroup("Runtime/Button")]
        public void Open()
        {
            IsOpened = true;
        }

        [FoldoutGroup("Runtime"), Button("Close"), HorizontalGroup("Runtime/Button")]
        public void Close()
        {
            IsOpened = false;
        }
    }
}
