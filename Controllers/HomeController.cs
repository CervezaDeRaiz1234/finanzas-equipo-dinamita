using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Finanzas2018.Models;
using Microsoft.AspNetCore.Authorization;

namespace Finanzas2018.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {

        private readonly IexClient _iexClient;

        public HomeController(IexClient iexClient)
        {
            _iexClient = iexClient;
        }

        [HttpPost]
        public async Task<ActionResult> Consulta(string simbolo)
        {
            var acciones = await _iexClient.Client.GetAsync(_iexClient.filtrar(simbolo));
            //acciones.EnsureSuccessStatusCode();
            var valor = acciones.Content.ReadAsStringAsync();
            Accion accion = Accion.FromJson(valor.Result);

            return View(accion);
        }

        public async Task<ActionResult> Index()
        {
            ViewData["Message"] = "Index";

            return View();
        }

        public async Task<ActionResult> About()
        {
            ViewData["Message"] = "About";

            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
}
