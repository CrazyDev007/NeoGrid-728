using Game.Application.UseCases;
using Game.Presentation.Presenters;
using TMPro;
using UnityEngine;

namespace Game.Presentation.Views
{
    public class CardView : MonoBehaviour, ICardView
    {
        private CardPresenter _cardPresenter;
        [SerializeField] private TextMeshPro cardText;

        public void Initialize(CardPresenter cardPresenter)
        {
            _cardPresenter = cardPresenter;
            _cardPresenter.Initialize();
        }

        public void OnMouseClicked2D() => _cardPresenter.OnCardClicked();

        public void CloseCardAfterDelay()
        {
            Debug.Log($"{name} not matched -> flip back");
            // Could use coroutine/animation here
        }

        public void OpenCard()
        {
            cardText.color = Color.green;
        }

        public void CloseCard()
        {
            cardText.color = Color.black;
        }

        public void LockCard()
        {
            cardText.color = Color.red;
        }

        public void UpdateCardIDText(int cardID)
        {
            cardText.text = cardID.ToString();
        }

        public CardUseCase GetCardEntity()
        {
            return null; //_cardPresenter.GetCardUseCase();
        }

        public void ActionOpenCard()
        {
        }

        public void ActionCloseCard()
        {
            _cardPresenter.HandleActionCloseCard();
        }

        public void ActionLockCard()
        {
            _cardPresenter.HandleActionLockCard();
        }

        public void UpdateCartID(int cardID)
        {
            _cardPresenter.HandleActionUpdateCardID(cardID);
        }
    }
}