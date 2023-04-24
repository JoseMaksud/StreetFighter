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

    public IActionResult Index(string game)
    {
        var streets = _streetService.GetIndexDto();
        ViewData["filter"] = string.IsNullOrEmpty(game) ? "all" : game;
        return View(streets);
    }

    public IActionResult Details(string Name)
    {
        var character = _streetService.GetDetailedDto(Name);
        return View(character);
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
