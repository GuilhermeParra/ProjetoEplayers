using System;
using System.Collections.Generic;
using System.IO;
using ProjetoEplayers.Interface;

namespace ProjetoEplayers.Models
{
    public class Noticias : EPlayersBase, INoticias
    {
        public int IdNoticias { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

         private const string PATH = "Database/Noticias.csv";
        
        public Noticias(){
            CreateFolderAndFile(PATH);
        }

        /// <summary>
        /// Cria a linha do CSV
        /// </summary>
        /// <param name="n">Objeto de noticias</param>
        public void Create(Noticias n)
        {
            string[] linhas = {PrepararLinha(n)};
            File.AppendAllLines(PATH, linhas);
        }

        /// <summary>
        /// Prepara a linha do CSV
        /// </summary>
        /// <param name="_n">Objeto de noticias</param>
        /// <returns>A linha do CSV</returns>
        private string PrepararLinha(Noticias _n){
            return $"{_n.IdNoticias};{_n.Titulo};{_n.Texto};{_n.Imagem}";
        }

        /// <summary>
        /// Deleta a linha do CSV
        /// </summary>
        /// <param name="IdNoticia">Parametro a ser buscado</param>
        public void Delete(int IdNoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        /// Lê as linhas do CSV
        /// </summary>
        /// <returns>Lista de noticias</returns>
        public List<Noticias> ReadAll()
        {
           List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias noticia = new Noticias();
                noticia.IdNoticias = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                noticias.Add(noticia);
            }
            return noticias;
        }

        /// <summary>
        /// Atualiza a linha do CSV
        /// </summary>
        /// <param name="n">Objeto de noticias</param>
        public void Update(Noticias n)
        {
           List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == n.IdNoticias.ToString());
            linhas.Add(PrepararLinha(n));
            RewriteCSV(PATH, linhas);
        }
    }
}