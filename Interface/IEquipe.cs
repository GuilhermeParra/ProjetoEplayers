using System.Collections.Generic;
using ProjetoEplayers.Models;

namespace ProjetoEplayers.Interface
{
    public interface IEquipe
    {
         void Create(Equipe e);
         List<Equipe> ReadAll();
         void Update(Equipe e);
         void Delete(int IdEquipe);
         
    }
}