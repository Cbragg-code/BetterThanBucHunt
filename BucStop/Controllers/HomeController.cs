﻿using BucStop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

/*
 * This file has the controllers for everything outside of the games
 * and game-related pages.
 */

namespace BucStop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GameService _gameService;
        private readonly MicroClient _httpClient;

        public HomeController(MicroClient AUclient, ILogger<HomeController> logger, GameService games)
        {
            _httpClient = AUclient;
            _logger = logger;
            _gameService = games;
        }

        //Sends the user to the deprecated Index page.
        public IActionResult Index()
        {
            return View(_gameService.GetGames());
        }

        //Takes the user to the admin page.
        //This view has now been removed from the Views folder and from _Layout.cshtml
        //public IActionResult Admin()
        //{
        //    return View();
        //}

        //Takes the user to the "Acceptable Use Policy" page.
        //Changed Privacy() to AUP().
        public IActionResult AUP()
        {
            return View();
        }

        //Takes the user to the game criteria page.
        public IActionResult GameCriteria()
        {
            return View();
        }

        // Pulls the About Us string from MicroClient and passes it as a parameter into the view
        public async Task<IActionResult> About()
        {
            string aboutUs = await _httpClient.GetAboutUsAsync();
            return View("About", aboutUs);
        }

        //If something goes wrong, this will take the user to a page explaining the error.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}