namespace StreetFighter.Models;

public class Character
{
    public string Name { get; set; }       
    public double Height { get; set; }
    public double Weight { get; set; }
    public string Enjoy { get; set; }
    public string Hates { get; set; }
    public string History { get; set; }
    public List<string> Game { get; set; }
    public string Image { get; set; }

    public Character()
    {
        Game = new List<string>();
    }
}