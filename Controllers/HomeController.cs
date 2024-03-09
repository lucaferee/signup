using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimoWeb.Models;

namespace PrimoWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    private static List<Prodotto> Prodotti = new List<Prodotto>();
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
    
        return View();

    }

    public IActionResult Privacy()
    {
        string? nomeUtente = HttpContext.Session.GetString("NomeUtente");
        if (string.IsNullOrEmpty(nomeUtente))
        return Redirect("\\home\\Prenotazione");
        return View();
    }
    [HttpGet]

     public IActionResult Prenotazione()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Conferma(Prenotazione p)
    {
        HttpContext.Session.SetString("NomeUtente", p.Nome);
        //Utente.Add(p);
        return View(p);
    }
     public IActionResult Purchase()
    {
        return View();
    }
     public IActionResult Cart(Prodotto p)
    {
        Prodotti.Add(p);
        return View(Prodotti);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
