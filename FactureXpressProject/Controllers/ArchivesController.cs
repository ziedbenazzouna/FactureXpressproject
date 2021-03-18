using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FactureXpressProject.Data;
using FactureXpressProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace FactureXpressProject.Controllers
{
    [Authorize]
    public class ArchivesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArchivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Archives
        public async Task<IActionResult> Index()
        {
            var commandes = _context.Commande.Include(c => c.Client).Where(x => x.Deleted == true).OrderByDescending(x => x.Date);
            return View(commandes.ToList());
        }

        // GET: Archives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Commande commande =  _context.Commande.Include(c => c.Client).SingleOrDefault(x => x.CommandeId == id);
            if (commande == null)
            {
                 return NotFound();
            }
            ViewBag.Produits = _context.Produits.Where(p => p.CommandeId == commande.CommandeId).ToList();
            ViewBag.totalCom = _context.Produits.Where(p => p.CommandeId == commande.CommandeId).Sum(item => item.Price * item.Qantity);
            return View(commande);
        }       

        // GET: Archives/Delete/5
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

        // POST: Archives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Commande commande = _context.Commande.Find(id);
            commande.Deleted = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CommandeExists(int id)
        {
            return _context.Commande.Any(e => e.CommandeId == id);
        }
    }
}
