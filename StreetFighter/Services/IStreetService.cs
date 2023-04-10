using StreetFighter.Models;
namespace StreetFighter.Services;

public interface IStreetService
{
    List<Character> GetCharacters();
    List<Game> GetGames();
    Character GetCharacter(string Name);
    IndexDto GetIndexDto();
    DetailsDto GetDetailedDto(string Name);
    Game GetGame(string Name);
}
