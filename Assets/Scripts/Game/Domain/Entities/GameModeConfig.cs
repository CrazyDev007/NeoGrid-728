namespace Game.Domain.Entities
{
    public class GameModeConfig
    {
        public GameMode Mode { get; set; }
        public GameModeConfig(GameMode mode) => Mode = mode;
    }
}