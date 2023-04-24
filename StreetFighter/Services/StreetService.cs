using System.Text.Json;
using StreetFighter.Models;

namespace StreetFighter.Services;

public class StreetService : IStreetService
{
    private readonly IHttpContextAccessor _session;
    private readonly string characterFile = @"Data\characters.json";
    private readonly string gamesFile = @"Data\games.json";

    public StreetService(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }

    public List<Character> GetCharacters()
    {
        PopularSessao();
        var characters = JsonSerializer.Deserialize<List<Character>>
            (_session.HttpContext.Session.GetString("Characters"));
        return characters;
    }

    public List<Game> GetGames()
    {
        PopularSessao();
        var games = JsonSerializer.Deserialize<List<Game>>
            (_session.HttpContext.Session.GetString("Games"));
        return games;
    }

    public Character GetCharacter(string Name)
    {
        var characters = GetCharacters();
        return characters.Where(c => c.Name == Name).FirstOrDefault();
    }

    public IndexDto GetIndexDto()
    {
        var chars = new IndexDto()
        {
            Characters = GetCharacters(),
            Games = GetGames()
        };
        return chars;
    }

    public DetailsDto GetDetailedCharacter(string Name)
    {
        var characters = GetCharacters().ToArray();
        var index = Array.IndexOf(characters, characters.Where(p => p.Name.Equals(Name)).FirstOrDefault());
        var character = new DetailsDto()
        {
            Current = characters[index],
            Prior = index - 1 < 0 ? null : characters[index - 1],
            Next = index + 1 >= characters.Count() ? null : characters[index + 1]
        };
        return character;
    }

    public Game GetGame(string Name)
    {
        var games = GetGames();
        return games.Where(g => g.Name == Name).FirstOrDefault();
    }

    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Games")))
        {
            _session.HttpContext.Session
            .SetString("Characters", LerArquivo(characterFile));
            _session.HttpContext.Session
            .SetString("Games", LerArquivo(gamesFile));
        }
    }

    private string LerArquivo(string fileName)
    {
        using (StreamReader leitor = new StreamReader(fileName))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }

    public DetailsDto GetDetailedDto(string Name)
    {
        throw new NotImplementedException();
    }
}
