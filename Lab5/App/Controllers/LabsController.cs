using ClassLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Authorize]
public class LabsController : Controller
{
    [HttpGet]
    public IActionResult First()
    {
        return View();
    }

    [HttpPost]
    public IActionResult First(string inputText)
    {
        var result = FirstLab.Execute(inputText);
        ViewBag.OutputResult = result;
        return View();
    }

    [HttpGet]
    public IActionResult Second()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Second(string inputText)
    {
        var result = SecondLab.Execute(inputText);
        ViewBag.OutputResult = result;
        return View();
    }

    [HttpGet]
    public IActionResult Third()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Third(string inputText)
    {
        var result = ThirdLab.Execute(inputText);
        ViewBag.OutputResult = result;
        return View();
    }
}
