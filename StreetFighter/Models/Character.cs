namespace StreetFighter.Models;

public class Character
{
    public string Name { get; set; }       
    public int Height { get; set; }
    public int Weight { get; set; }
    public string Enjoy { get; set; }
    public string Hates { get; set; }
    public string History { get; set; }
    public List<string> Games { get; set; }
    public string Image { get; set; }

    public Character()
    {
        Games = new List<string>();
    }
}