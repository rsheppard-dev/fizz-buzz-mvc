using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using fizz_buzz_mvc.Models;

namespace fizz_buzz_mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult FBPage()
    {
        FizzBuzz model = new();

        model.StartValue = 1;
        model.EndValue = 100;
        model.FizzValue = 3;
        model.BuzzValue = 5;

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult FBPage(FizzBuzz fizzBuzz)
    {
        List<string> fbItems = new();

        bool fizz;
        bool buzz;

        for (int i = fizzBuzz.StartValue; i <= fizzBuzz.EndValue; i++)
        {
            fizz = (i % fizzBuzz.FizzValue == 0);
            buzz = (i % fizzBuzz.BuzzValue == 0);

            if (fizz == true && buzz == true)
            {
                fbItems.Add("FizzBuzz");
            }
            else if (fizz == true)
            {
                fbItems.Add("Fizz");
            }
            else if (buzz == true)
            {
                fbItems.Add("Buzz");
            }
            else
            {
                fbItems.Add(i.ToString());
            }
        }

        fizzBuzz.Result = fbItems;

        return View(fizzBuzz);
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

