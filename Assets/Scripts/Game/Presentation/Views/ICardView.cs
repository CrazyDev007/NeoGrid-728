using Game.Application.UseCases;

namespace Game.Presentation.Views
{
    public interface ICardView
    {
        void OpenCard();
        void CloseCard();
        void LockCard();
        void UpdateCardIDText(int cardID);

        CardUseCase GetCardEntity();

        void ActionOpenCard();
        void ActionCloseCard();
        void ActionLockCard();
        void UpdateCartID(int cardID);
    }
}