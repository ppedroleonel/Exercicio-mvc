using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Exercicio1.Models;
using Exercicio1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Exercicio1.Controllers
{
    public class EventoController : Controller
    {
        private static List<Evento> _eventos = new()
        {
          new Evento { Id = 1, Nome = "Harry Potter CCXP", Descricao = "Evento para divulgação da serie", Local = "Expo Center", DataEvento = new DateTime(2026, 12, 21, 13,30,0), QuantidadeVagas = 350, ValorIngresso = 99.90m},  
          new Evento { Id = 2, Nome = "Feira do Livro USP", Descricao = "Evento para aproximar os leitores", Local = "USP Butantã", DataEvento = new DateTime(2026, 11, 25, 10,0,0), QuantidadeVagas = 350, ValorIngresso = 22.90m}  
        };

        public IActionResult Index()
        {
            return View(_eventos);
        }
        public IActionResult Detalhes(int id)
        {
            var evento = _eventos.FirstOrDefault(a => a.Id == id);
            if(evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }
    
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Evento evento)
        {
            if(!ModelState.IsValid)
            {
                return View(evento);
            }

            evento.Id = _eventos.Any() ? _eventos.Max(e => e.Id) + 1 : 1;
            _eventos.Add(evento);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Buscar()
        {
            return View(new BuscaEventoViewModel());
        }


        [HttpPost]
        public IActionResult Buscar(BuscaEventoViewModel vm)
        {
            if(!string.IsNullOrEmpty(vm.NomeBusca)) 
            {
                vm.Resultados = _eventos.Where(a => a.Nome.Contains(vm.NomeBusca, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View(vm);
        }
        
    }
}