namespace Game.Domain.Entities
{
    public enum CardState
    {
        Closed,
        Opened,
        Matched,
    }

    public class CardEntity
    {
        public int CardId { get; set; }
        public bool IsMatched { get; set; }
        public CardState CardState { get; set; }
        public bool IsLocked { get; set; }
    }
}