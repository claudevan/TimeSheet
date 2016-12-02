using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Modelo;

namespace TimeSheet.Entity.Contractos
{
    public interface IMarcacao : IDisposable
    {
        Marcacao GetById(int id);
        List<Marcacao> Get();
        void Update(Marcacao entity);
        void Create(Marcacao entity);
        void Delete(Marcacao entity);

    }
}
