using System.Threading.Tasks;
using Game.Application.UseCases;
using Game.Presentation;
using Game.Presentation.Views;
using UnityEngine;

namespace Test
{
    public class TestGameManager : MonoBehaviour
    {
        public static TestGameManager Instance;

        public ICardView SelectedCardView;

        private void Awake()
        {
            if (Instance != null && Instance == this)
            {
                Destroy(gameObject);
            }

            Instance = this;
        }

        /*public async Task CompareCard(ICardView cardViewA, ICardView cardViewB)
        {
            await Task.Delay(1000);

            if (CardUseCase.GetCardID(cardViewA.GetCardEntity()) == CardUseCase.GetCardID(cardViewB.GetCardEntity()))
            {
                Debug.Log("Same Cards");
                cardViewA.ActionLockCard();
                cardViewB.ActionLockCard();
            }
            else
            {
                Debug.Log("Different Cards");
                cardViewA.ActionCloseCard();
                cardViewB.ActionCloseCard();
            }
            SelectedCardView = null;
        }*/
    }
}