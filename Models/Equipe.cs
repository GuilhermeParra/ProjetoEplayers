using System;
using System.Collections.Generic;
using System.IO;
using ProjetoEplayers.Interface;

namespace ProjetoEplayers.Models
{
    public class Equipe : EPlayersBase, IEquipe 
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/Equipe.csv";

        public Equipe(){
            CreateFolderAndFile(PATH);
        }
        /// <summary>
        /// Cria um caminho para o CSV
        /// </summary>
        /// <param name="e">Objeto de Equipe</param>
        public void Create(Equipe e)
        {
            string[] linhas = {PrepararLinha(e)};
            File.AppendAllLines(PATH, linhas);
        }

        /// <summary>
        /// Prepara a linha do CSV
        /// </summary>
        /// <param name="_e">Objeto de Equipe</param>
        /// <returns>O Id, o nome e a imagem da equipe</returns>
        private string PrepararLinha(Equipe _e){
            return $"{_e.IdEquipe};{_e.Nome};{_e.Imagem}";
        }

        /// <summary>
        /// Deleta a linha do CSV
        /// </summary>
        /// <param name="IdEquipe">Parametro a ser buscado</param>
        public void Delete(int IdEquipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == IdEquipe.ToString());
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        /// Le todas as linhas do CSV
        /// </summary>
        /// <returns>Lista de equipes</returns>
        public List<Equipe> ReadAll()
        {
           List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        /// <summary>
        /// Atualiza as linhas do CSV
        /// </summary>
        /// <param name="e">Objeto de equipe</param>
        public void Update(Equipe e)
        {
           List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add(PrepararLinha(e));
            RewriteCSV(PATH, linhas);
        }
    }
}