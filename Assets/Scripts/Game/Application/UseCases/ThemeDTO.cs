namespace Game.Application.UseCases
{
    public class ThemeDto
    {
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }

        public ThemeDto(string name, string backgroundColor, string textColor)
        {
            Name = name;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
        }
    }
}