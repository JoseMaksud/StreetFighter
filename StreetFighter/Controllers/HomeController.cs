using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StreetFighter.Models;
using StreetFighter.Services;

namespace StreetFighter.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IStreetService _streetService;

    public HomeController(ILogger<HomeController> logger, IStreetService streetService)
    {
        _logger = logger;
        _streetService = streetService;
    }

    public IActionResult Index(string jogo)
    {
        var persos = _streetService.GetPersonagemDto();
        ViewData["filter"] = string.IsNullOrEmpty(jogo) ? "all" : jogo;
        return View(persos);
    }

    public IActionResult Details(string Nome)
    {
        var personagem = _streetService.GetDetailedPersonagem(Nome);
        return View(personagem);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
