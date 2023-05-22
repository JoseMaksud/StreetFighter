using StreetFighter.Models;
namespace StreetFighter.Services;

public interface IStreetService
{
    List<Personagem> GetPersonagens();
    List<Jogo> GetJogos(); 
    Personagem GetPersonagem(string Nome);
    PersonagemDto GetPersonagemDto();
    DetailsDto GetDetailedPersonagem(string Nome);
    Jogo GetJogo(String Nome);
}
