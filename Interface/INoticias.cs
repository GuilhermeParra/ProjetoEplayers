using System.Collections.Generic;
using ProjetoEplayers.Models;

namespace ProjetoEplayers.Interface
{
    public interface INoticias
    {
         void Create(Noticias n);
         List<Noticias> ReadAll();
         void Update(Noticias n);
         void Delete(int IdNoticia);
    }
}