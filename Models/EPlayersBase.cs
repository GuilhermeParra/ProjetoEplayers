using System.Collections.Generic;
using System.IO;

namespace ProjetoEplayers.Models
{
    public class EPlayersBase
    {
        /// <summary>
        /// Cria uma pasta e um arquivo csv caso nao exista
        /// </summary>
        /// <param name="_path">Caminho a ser criado</param>
        public void CreateFolderAndFile(string _path){
        string folder   = _path.Split("/")[0];
            

            if(!Directory.Exists(folder)){
                Directory.CreateDirectory(folder);
            }

            if(!File.Exists(_path)){
                File.Create(_path).Close();
            }
        }
        /// <summary>
        /// Lê todas as linhas do CSV
        /// </summary>
        /// <param name="PATH">Caminho gerado</param>
        /// <returns></returns>
        public List<string> ReadAllLinesCSV(string PATH){
            
            List<string> linhas = new List<string>();
            using(StreamReader file = new StreamReader(PATH))
            {
                string linha;
                while((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }
        /// <summary>
        /// Reescreve as linhas do CSV
        /// </summary>
        /// <param name="PATH">Caminho gerado</param>
        /// <param name="linhas">Linhas de uma lista de string</param>
        public void RewriteCSV(string PATH, List<string> linhas)
        {
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }

    }
}

