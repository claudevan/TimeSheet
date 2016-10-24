using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TimeSheet.Entity.Contexto;
using TimeSheet.Modelo;
using TimeSheet.ViewModels.Marcacao;

namespace TimeSheet.Controllers
{
    public class MarcacaoController : Controller
    {
        private TimeSheetDataContext db = new TimeSheetDataContext();

        // GET: Marcacao
        public ActionResult Index()
        {
            var marcacoes = db.Marcacao.ToList();
            List<MarcacaoVM> lstMarcacao = new List<MarcacaoVM>();

            foreach (var marcacao in marcacoes)
            {
                MarcacaoVM mvm = new MarcacaoVM();
                Map(marcacao, mvm);

                lstMarcacao.Add(mvm);
            }

            return View(lstMarcacao);
        }

        // GET: Marcacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcacao marcacao = db.Marcacao.Find(id);
            if (marcacao == null)
            {
                return HttpNotFound();
            }
            var marcacaoVM = new MarcacaoVM();
            Map(marcacao, marcacaoVM);

            return PartialView(marcacaoVM);
        }

        // GET: Marcacao/Create
        public PartialViewResult Create()
        {
            return PartialView();
        }

        // POST: Marcacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,DataMarcacao,EntradaManha,SaidaManha,EntradaTarde,SaidaTarde,Descricao")] MarcacaoVM marcacaoVM)
        {
            if (ModelState.IsValid)
            {
                Marcacao marcacao = new Marcacao();
                Map(marcacaoVM, marcacao);

                db.Marcacao.Add(marcacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marcacaoVM);
        }

        // GET: Marcacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcacao marcacao = db.Marcacao.Find(id);
            if (marcacao == null)
            {
                return HttpNotFound();
            }

            var marcacaoVM = new MarcacaoVM();
            Map(marcacao, marcacaoVM);

            return PartialView(marcacaoVM);
        }

        // POST: Marcacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,DataMarcacao,EntradaManha,SaidaManha,EntradaTarde,SaidaTarde,Descricao")] MarcacaoVM marcacaoVM)
        {
            Marcacao marcacao = new Marcacao();
            Map(marcacaoVM, marcacao);

            if (ModelState.IsValid)
            {
                db.Entry(marcacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marcacaoVM);
        }

        // GET: Marcacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcacao marcacao = db.Marcacao.Find(id);
            if (marcacao == null)
            {
                return HttpNotFound();
            }

            var marcacaoVM = new MarcacaoVM();
            Map(marcacao, marcacaoVM);

            return PartialView(marcacaoVM);
        }

        // POST: Marcacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marcacao marcacao = db.Marcacao.Find(id);
            db.Marcacao.Remove(marcacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void Map(Marcacao marcacao, MarcacaoVM marcacaoVM)
        {
            marcacaoVM.Id = marcacao.Id;
            marcacaoVM.UserId = marcacao.UserId;
            marcacaoVM.DataMarcacao = marcacao.DataMarcacao;
            marcacaoVM.EntradaManha = new DateTime(marcacao.EntradaManha.Value);
            marcacaoVM.SaidaManha = new DateTime(marcacao.SaidaManha.Value);
            marcacaoVM.EntradaTarde = new DateTime(marcacao.EntradaTarde.Value);
            marcacaoVM.SaidaTarde = new DateTime(marcacao.SaidaTarde.Value);
            marcacaoVM.Descricao = marcacao.Descricao;
        }

        private void Map(MarcacaoVM marcacaoVM, Marcacao marcacao)
        {
            marcacao.Id = marcacaoVM.Id;
            marcacao.UserId = marcacaoVM.UserId;
            marcacao.DataMarcacao = marcacaoVM.DataMarcacao;
            marcacao.EntradaManha = marcacaoVM.EntradaManha.Value.Ticks;
            marcacao.SaidaManha = marcacaoVM.SaidaManha.Value.Ticks;
            marcacao.EntradaTarde = marcacaoVM.EntradaTarde.Value.Ticks;
            marcacao.SaidaTarde = marcacaoVM.SaidaTarde.Value.Ticks;
            marcacao.Descricao = marcacaoVM.Descricao;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
