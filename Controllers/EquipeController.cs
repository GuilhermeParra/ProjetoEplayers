using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEplayers.Models;

namespace ProjetoEplayers.Controllers

{
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }
        public IActionResult Cadastrar(IFormCollection form){
            Equipe equipe = new Equipe();
            equipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            equipe.Nome = form["Nome"];
            equipe.Imagem = form["Imagem"];

            equipeModel.Create(equipe);
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe");

        }
    }
}