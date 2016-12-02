using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TimeSheet.Entity.Contexto;
using TimeSheet.Entity.Contractos;
using TimeSheet.Modelo;

namespace TimeSheet.Entity.Repository
{
    public class MarcacaoRepository : IMarcacao
    {
        private TimeSheetDataContext _db = null;

        public MarcacaoRepository(TimeSheetDataContext db)
        {
            _db = db;
        }

        public void Create(Marcacao entity)
        {
            _db.Marcacao.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Marcacao entity)
        {
            _db.Marcacao.Remove(entity);
            _db.SaveChanges();
        }

        public List<Marcacao> Get()
        {
            return _db.Marcacao.ToList();
        }

        public Marcacao GetById(int id)
        {
            return _db.Marcacao.Find(id);
        }

        public void Update(Marcacao entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
