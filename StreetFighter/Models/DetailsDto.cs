namespace StreetFighter.Models;
public class DetailsDto
{
    public Character Prior { get; set; }
    public Character Current { get; set; }
    public Character Next { get; set; }
    public List<Game> Games { get; set; }
}
