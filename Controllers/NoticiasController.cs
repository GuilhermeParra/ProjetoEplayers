using System;
using System.IO;
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
            noticia.IdNoticias = Int32.Parse(form["IdNoticias"]);
            noticia.Titulo = form["Titulo"];
            noticia.Texto = form["Texto"];
            
            //Upload da imagem
            var file    = form.Files[0];
            //patasA, pastaB, pastaC, arquivo.PDF
            //patasA/pastaB/pastaC/arquivo.PDF
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

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
                noticia.Imagem   = file.FileName;
            }
            else
            {
                noticia.Imagem   = "padrao.png";
            }
           
            //Fim do upload Imagem

            noticiaModel.Create(noticia);
            ViewBag.Noticias = noticiaModel.ReadAll();

            return LocalRedirect("~/Noticias");

        }
        [Route("Noticias/{id}")]
        public IActionResult Excluir(int id){
            noticiaModel.Delete(id);
            return LocalRedirect("~/Noticias");
        }
    }
}