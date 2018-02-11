using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PieApp.Models;
using PieApp.ViewModels;

namespace PieApp.Controllers
{
    //main paga com as tortas( images and links etc)
    public class HomeController : Controller
    {
        //recebe todas as strings da page e traduz para pt-BR, usa DI no ctor
        private readonly IStringLocalizer<HomeController> _stringLocalizer;

        //cria uma instância do pieRepository
        private readonly IPieRepository _pieRepository;

        //inicia a instância com injeção de dependência
        public HomeController(IPieRepository pieRepository)
        {
            //sem injection defendency, n tem param; _pieRepository = new MockPieRepository();
            _pieRepository = pieRepository; //com injeção de dependência
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //pies recebe os dados do banco
            var pies = _pieRepository.GetAllPies().OrderBy(m => m.Name);

            var homeViewModel = new HomeViewModel()
            {
                Title = "Bem Vindo ao Mr. Cake Ninja",
                Pies = pies.ToList()
            };

            return View(homeViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }
    }
}
