using System.Collections.Generic;
using Game.Unity.Views;
using UnityEngine;

namespace Game.Unity.EntryPoint
{
    public class GameInitializer : MonoBehaviour
    {
        /*
         * public PlayerController playerController;

        private void Awake()
        {
            // 1. Create the core logic (dependency).
            IHealth playerHealth = new HealthSystem(100);

            // 2. Inject the dependency into the PlayerController.
            playerController.Initialize(playerHealth);
        }
         */

        [SerializeField] private CardView cardViewPrefab;

        [Range(2, 6)] [SerializeField] private int rowCount;
        [Range(2, 6)] [SerializeField] private int columnCount;

        [Range(1, 4)] [SerializeField] private float spaceBetweenCards;

        private void Awake()
        {
            var cardViews = new List<CardView>();
            // Card Creation Logic
            var ratio = spaceBetweenCards / 2;
            var startX = -((columnCount - 1) * ratio);
            var startY = -((rowCount - 1) * ratio);
            for (var i = 0; i < columnCount; i++)
            {
                for (var j = 0; j < rowCount; j++)
                {
                    cardViews.Add(Instantiate(cardViewPrefab,
                        new Vector3(startX + i * spaceBetweenCards, startY + j * spaceBetweenCards, 0),
                        Quaternion.identity));
                }
            }

            // Initialize Cards
            var halfLength = cardViews.Count / 2;
            for (var i = 0; i < halfLength; i++)
            {
                cardViews[i].UpdateCartID(i);
                cardViews[i + halfLength].UpdateCartID(i);
            }

            // Shuffle Cards
            for (var i = cardViews.Count - 1; i > 0; i--)
            {
                var randomIndex = Random.Range(0, i + 1);
                (cardViews[i], cardViews[randomIndex]) = (cardViews[randomIndex], cardViews[i]);
            }
        }

        private void Awake_1()
        {
            var ratio = spaceBetweenCards / 2;
            var startX = -((columnCount - 1) * ratio);
            for (var i = 0; i < columnCount; i++)
            {
                Instantiate(cardViewPrefab, new Vector3(startX + (i * spaceBetweenCards), 0, 0),
                    Quaternion.identity);
            }
        }
    }
}