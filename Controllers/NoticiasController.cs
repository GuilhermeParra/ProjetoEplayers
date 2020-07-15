using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEplayers.Models;

namespace ProjetoEplayers.Controllers

{
    public class NoticiasController : Controller
    {
        Noticias noticiaModel = new Noticias();
        public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel.ReadAll();
            return View();
        }
        public IActionResult Cadastrar(IFormCollection form){
            Noticias noticia = new Noticias();
            noticia.IdNoticia = Int32.Parse(form["IdEquipe"]);
            noticia.Titulo = form["Titulo"];
            noticia.Texto = form["Texto"];
            noticia.Imagem = form["Imagem"];

            noticiaModel.Create(noticia);
            ViewBag.Noticias = noticiaModel.ReadAll();

            return LocalRedirect("~/Noticias");

        }
    }
}