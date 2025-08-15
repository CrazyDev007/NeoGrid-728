namespace Game.Core.Entities
{
    public enum CardState
    {
        Closed,
        Opened,
        Locked
    }

    public class CardEntity
    {
        public int CardId { get; set; }

        public CardState CardState { get; set; }
    }
}