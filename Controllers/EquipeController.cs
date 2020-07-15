using System;
using System.IO;
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

            //Upload da imagem
            var file    = form.Files[0];
            //patasA, pastaB, pastaC, arquivo.PDF
            //patasA/pastaB/pastaC/arquivo.PDF
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                equipe.Imagem   = file.FileName;
            }
            else
            {
                equipe.Imagem   = "padrao.png";
            }
           
            //Fim do upload Imagem

            equipeModel.Create(equipe);
           
            return LocalRedirect("~/Equipe");

        }
        [Route("Equipe/{id}")]
        public IActionResult Excluir(int id){
            equipeModel.Delete(id);
            return LocalRedirect("~/Equipe");
        }
    }
}