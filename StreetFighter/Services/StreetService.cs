using System.Text.Json;
using StreetFighter.Models;

namespace StreetFighter.Services;

public class StreetService : IStreetService
{
    private readonly IHttpContextAccessor _session;
    private readonly string personagensFile = @"Data\personagens.json";
    private readonly string jogosFile = @"Data\jogos.json";

    public StreetService(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }

    public List<Personagem> GetPersonagens()
    {
        PopularSessao();
        var personagens = JsonSerializer.Deserialize<List<Personagem>>
        (_session.HttpContext.Session.GetString("Personagens"));
        return personagens;
    }

    public List<Jogo> GetJogos()
    {
        PopularSessao();
        var jogos = JsonSerializer.Deserialize<List<Jogo>>
        (_session.HttpContext.Session.GetString("Jogos"));
        return jogos;
    }

    public Personagem GetPersonagem(string Nome)
    {
        var personagens = GetPersonagens();
        return personagens.Where(p => p.Nome == Nome).FirstOrDefault();
    }

    public PersonagemDto GetPersonagemDto()
    {
        var perso = new PersonagemDto()
        {
            Personagens = GetPersonagens(),
            Jogos = GetJogos()
        };
        return perso;
    }

     public DetailsDto GetDetailedPersonagem(string Nome)
    {
        var personagens = GetPersonagens().ToArray();
        var index = Array.IndexOf(personagens, personagens.Where(p => p.Nome.Equals(Nome)).FirstOrDefault());
        var perso = new DetailsDto()
        {
            Current = personagens[index],
            Prior = index - 1 < 0 ? null : personagens[index - 1],
            Next = index + 1 >= personagens.Count() ? null : personagens[index + 1]
        };
        return perso;
    }

    public Jogo GetJogo(string Nome)
    {
        var jogos = GetJogos();
        return jogos.Where(p => p.Nome == Nome).FirstOrDefault();
    }

    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Jogos")))
        {
            _session.HttpContext.Session.SetString("Personagens", LerArquivo(personagensFile));
            _session.HttpContext.Session.SetString("Jogos", LerArquivo(jogosFile));
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
}
