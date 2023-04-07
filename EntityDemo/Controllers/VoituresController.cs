using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityDemo.Models;
using EntityDemo.Models.Context;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EntityDemo.Controllers
{
    public class VoituresController : Controller
    {
        private readonly MyDbContext _context;

        public VoituresController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Voitures
        public IActionResult Index()
        {

            if (_context.Voitures != null)
            {
                return View(_context.Voitures.ToList());
            }

            return Problem("Entity set 'MyDbContext.Voitures'  is null.");

            /*
              return _context.Voitures != null ? 
                          View(_context.Voitures.ToList()) :
                          Problem("Entity set 'MyDbContext.Voitures'  is null.");


            // Equivalent en ternaire
            */
        } 

        // GET: Voitures/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voiture = _context.Voitures.Find(id);
            
            //Exemple Includes 

            //List<School> schools = _context.Schools.Include(s => s.Address).Include(s => s.Administrators).Include(s => s.Calendars).ThenInclude(c => c.Stages).Where(s => s.Id == id).ToList();

            if (voiture == null)
            {
                return NotFound();
            }

            return View(voiture);
        }

        // GET: Voitures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Voiture voiture)
        {

           
            if (ModelState.IsValid)
            {

                //_context.Voitures.Add(voiture);

                _context.Add(voiture);

                _context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }

            return View(voiture);
        }

        // GET: Voitures/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voiture = _context.Voitures.Find(id);
            if (voiture == null)
            {
                return NotFound();
            }
            return View(voiture);
        }

        // POST: Voitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Voiture voiture)
        {
            if (id != voiture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Voitures.Update(voiture);

                    _context.Update(voiture);

                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoitureExists(voiture.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(voiture);
        }

        // GET: Voitures/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voiture = _context.Voitures.Find(id);

            if (voiture == null)
            {
                return NotFound();
            }

            return View(voiture);
        }

        // POST: Voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var voiture = _context.Voitures.Find(id);

            if (voiture == null)
            {
                return NotFound();
            }


            //_context.Voitures.Remove(voiture);
            _context.Remove(voiture);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool VoitureExists(int? id)
        {
          return (_context.Voitures.Any(e => e.Id == id));

            // Exemple pour les mails
            // _context.Users.Any(u => u.Email == email)

            // Retourne vrai si il y a deja un email correspondant ou faux si non
            // Permet de tester a l'enregistrement des users
        }
    }
}
