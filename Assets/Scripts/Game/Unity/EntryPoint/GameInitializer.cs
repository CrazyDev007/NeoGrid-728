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
            var ratio = spaceBetweenCards / 2;
            var startX = -((columnCount - 1) * ratio);
            var startY = -((rowCount - 1) * ratio);
            for (var i = 0; i < columnCount; i++)
            {
                for (var j = 0; j < rowCount; j++)
                {
                    Instantiate(cardViewPrefab,
                        new Vector3(startX + i * spaceBetweenCards, startY + j * spaceBetweenCards, 0),
                        Quaternion.identity);
                }
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