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

        [FoldoutGroup("Reference")]
        public GameObject coinPrefab; // Referencen til prefab-objektet af mønten

        [FoldoutGroup("Runtime")]
        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                animator.SetBool("IsOpened", isOpened);
                if (isOpened)
                {
                    SpawnCoins();
                }
            }
        }
        private bool isOpened;

        // Radius for detecting player proximity
        [FoldoutGroup("Runtime")]
        public float interactRadius = 2f;

        // Reference to the player GameObject
        private GameObject player;

        // Antallet af mønter, der skal spawnes
        [FoldoutGroup("Runtime")]
        public int numberOfCoinsToSpawn = 2;

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

        // Function to spawn coins when the chest is opened
        private void SpawnCoins()
        {
            for (int i = 0; i < numberOfCoinsToSpawn; i++)
            {
                // Generate random offsets for x and y positions
                float xOffset = Random.Range(-0.5f, 0.5f); // Adjust the range as needed
                float yOffset = Random.Range(-0.5f, 0.5f); // Adjust the range as needed

                // Spawn coin prefabs based on numberOfCoinsToSpawn
                Instantiate(coinPrefab, transform.position + new Vector3(xOffset, yOffset, 0), Quaternion.identity);
            }
        }

        [FoldoutGroup("Runtime"), Button("Open"), HorizontalGroup("Runtime/Button")]
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
