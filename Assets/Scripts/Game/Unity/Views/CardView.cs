using Game.Core.Entities;
using Game.Presentation.MVP;
using TMPro;
using UnityEngine;

namespace Game.Unity.Views
{
    public class CardView : MonoBehaviour, ICardView
    {
        private CardPresenter _cardPresenter;
        [SerializeField] private TextMeshPro cardText;

        private void Awake()
        {
            _cardPresenter = new CardPresenter(this);
        }

        public void OnMouseClicked2D() => _cardPresenter.OnCardClicked();

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

        public void UpdateCardID(int cardID)
        {
            cardText.text = cardID.ToString();
        }

        public CardEntity GetCardEntity()
        {
            return _cardPresenter.GetCardEntity();
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
    }
}