namespace StreetFighter.Models;

public class Personagem
{
    public string Nome { get; set; }
    public double Altura { get; set; }
    public double Peso { get; set; }
    public string Gosta { get; set; }
    public string Odeia { get; set; }
    public string Historia { get; set; }
    public List<String> Jogo { get; set; }
    public string Imagem { get; set; }

    public Personagem()
    {
        Jogo = new List<string>(); 
    }
}
