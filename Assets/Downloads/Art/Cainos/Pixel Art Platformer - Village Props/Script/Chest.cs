using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.LucidEditor;

namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class Chest : MonoBehaviour
    {
        public Chest chest;
        [FoldoutGroup("Reference")]
        public Animator animator;

        [FoldoutGroup("Reference")]
        public GameObject coinPrefab; // Reference til prefab-objektet af mønten

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
                    Destroy(chest);
                }
            }
        }
        private bool isOpened;

        // Radius for detecting player afstand
        [FoldoutGroup("Runtime")]
        public float interactRadius = 2f;

        // Reference til player GameObject
        private GameObject player;

        // Antallet af mønter, der skal spawnes
        [FoldoutGroup("Runtime")]
        public int numberOfCoinsToSpawn = 2;

        private void Start()
        {
            // Find  player GameObject via tag
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            // Check om player er tæt og om der trykkes e
            if (Vector2.Distance(transform.position, player.transform.position) <= interactRadius && Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }

        
        private void Interact()
        {
            // Toggle the state of the chest
            IsOpened = !IsOpened;
        }

        // Function til spawnw coins når den åbnet
        private void SpawnCoins()
        {
            for (int i = 0; i < numberOfCoinsToSpawn; i++)
            {
                // Radisu de skal spawne inden for
                float xOffset = Random.Range(-0.5f, 0.5f); 
                float yOffset = Random.Range(0f, 3f); 

                // Spawn coin prefabs i forhold til numberOfCoinsToSpawn
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
