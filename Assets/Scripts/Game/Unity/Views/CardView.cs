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

        private void OnMouseClicked2D(bool self)
        {
            _cardPresenter.OnCardClicked(self);
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
    }
}