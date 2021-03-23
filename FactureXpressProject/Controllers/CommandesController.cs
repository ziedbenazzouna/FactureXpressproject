using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FactureXpressProject.Data;
using FactureXpressProject.Models;
using FactureXpressProject.Report;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace FactureXpressProject.Controllers
{
    [Authorize]
    public class CommandesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;

        public CommandesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Commandes
        public async Task<IActionResult> Index()
        {
            var commandes = _context.Commande.Include(c => c.Client).Include(p=>p.Produits).Where(x => x.Deleted == false).OrderByDescending(x => x.Date);
            ViewBag.commandes = commandes;
            var query2 = from d in _context.Commande
                         where d.Deleted == false
                         select d.ClientId;
            var query = from c in _context.Client
                        where query2.Contains(c.ClientId)
                        select c;
            ViewBag.ClientId = new SelectList(query, "ClientId", "FullName");
            return View();
        }

        [HttpGet]
        public int GetTotal(int id)
        {
            Commande commande = _context.Commande.Include(c => c.Client).SingleOrDefault(x => x.CommandeId == id);
            ViewBag.Produits = _context.Produits.Where(p => p.CommandeId == commande.CommandeId).ToList();
            ViewBag.totalCom = _context.Produits.Where(p => p.CommandeId == commande.CommandeId).Sum(item => item.Price * item.Qantity);
            return ViewBag.totalCom;
        }

        public ActionResult Search(int Id)
        {
            var commandes = _context.Commande.Include(c => c.Client).Include(p => p.Produits).Where(x => x.Deleted == false).OrderByDescending(x => x.Date);

            if (Id != 0)
            {
                commandes = commandes.Where(s => s.Client.ClientId == Id).OrderByDescending(x => x.Date);
            }
            return PartialView("SearchPartial", commandes);
        }

        public ActionResult Report(int Id)
        {
            CommandeReport commandeReport = new CommandeReport(_env, _context);
            var commandes = _context.Commande.Include(c => c.Client).Where(x => x.Deleted == false);

            if (Id != 0)
            {
                commandes = commandes.Where(s => s.Client.ClientId == Id);
            }

            byte[] abytes = commandeReport.PrepareReport(commandes.ToList());

            return File(abytes, "application/pdf");
        }

        // GET: Commandes/Details/5
        public async Task<IActionResult> Details(int? id)
        {            
            if (id == null)
            {
                return NotFound();
            }
            Commande commande = _context.Commande.Include(c => c.Client).SingleOrDefault(x => x.CommandeId == id);
            if (commande == null)
            {
                return NotFound();
            }
            ViewBag.Produits = _context.Produits.Where(p => p.CommandeId == commande.CommandeId).ToList();
            ViewBag.totalCom = _context.Produits.Where(p => p.CommandeId == commande.CommandeId).Sum(item => item.Price * item.Qantity);
            return View(commande);
        }

        // GET: Commandes/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "FullName");
            return View();
        }

        // POST: Commandes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create ([FromBody] GeneralModel genralmodel)
        {
            Client cl = new Client();
            Commande c = new Commande();
           
            Client client = _context.Client.Find(genralmodel.ClientId);

            if (client == null)
            {
                cl.FullName = genralmodel.FullName;
                cl.Matricule = genralmodel.Matricule;
                cl.PhoneNumber = genralmodel.PhoneNumber;
                cl.Email = genralmodel.Email;
                _context.Client.Add(cl);
                _context.SaveChanges();

                c.ClientId = cl.ClientId;
                c.Date = DateTime.Now;
                c.WithStamp = genralmodel.WithStamp;
                _context.Commande.Add(c);
                _context.SaveChanges();

                genralmodel.Produits.ToList().ForEach(x => x.CommandeId = c.CommandeId);

                foreach (Produit produit in genralmodel.Produits)
                {
                    _context.Produits.Add(produit);
                }
                _context.SaveChanges();
            }
            else
            {
                c.ClientId = genralmodel.ClientId;
                c.Date = DateTime.Now;
                c.WithStamp = genralmodel.WithStamp;
                _context.Commande.Add(c);
                _context.SaveChanges();

                genralmodel.Produits.ToList().ForEach(x => x.CommandeId = c.CommandeId);
                foreach (Produit produit in genralmodel.Produits)
                {
                    _context.Produits.Add(produit);
                }
                _context.SaveChanges();
            }
            int insertedRecords = _context.SaveChanges();
            ViewBag.ClientId = new SelectList(_context.Client, "ClientId", "FullName", c.ClientId);
            return Json(insertedRecords);
        }

        // GET: Commandes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Commande commande = _context.Commande.Include(c => c.Client).SingleOrDefault(x => x.CommandeId == id);
            ViewBag.Produits = _context.Produits.Where(p => p.CommandeId == commande.CommandeId).ToList();
            ViewBag.totalCom = _context.Produits.Where(p => p.CommandeId == commande.CommandeId).Sum(item => item.Price * item.Qantity);
            if (commande == null)
            {
                return NotFound();
            }
            ViewBag.ClientId = new SelectList(_context.Client, "ClientId", "FullName", commande.ClientId);
            return View(commande);
        }

        // POST: Commandes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([FromBody] List<Produit> produits)
        {
            int commandId = produits.FirstOrDefault().CommandeId;
            List<Produit> OldProduits = _context.Produits.Where(p => p.CommandeId == commandId).ToList();
            foreach (Produit p in OldProduits)
            {
                _context.Produits.Remove(p);
            }
            foreach (Produit p in produits)
            {
                _context.Produits.Add(p);
            }
            _context.SaveChanges();

            int insertedRecords = _context.SaveChanges();
            return Json(insertedRecords);
        }

        // GET: Commandes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Commande commande = _context.Commande.Include(c => c.Client).SingleOrDefault(x => x.CommandeId == id);
            ViewBag.Produits = _context.Produits.Where(p => p.CommandeId == commande.CommandeId).ToList();
            ViewBag.totalCom = _context.Produits.Where(p => p.CommandeId == commande.CommandeId).Sum(item => item.Price * item.Qantity);
            if (commande == null)
            {
                return NotFound();
            }
            return View(commande);
        }

        // POST: Commandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Commande commande = _context.Commande.Find(id);
            commande.Deleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CommandeExists(int id)
        {
            return _context.Commande.Any(e => e.CommandeId == id);
        }
    }
}
