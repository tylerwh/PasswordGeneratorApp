using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PasswordGeneratorApp.Models;

namespace PasswordGeneratorApp.Controllers
{
    public class PasswordsController : Controller
    {
        private readonly PasswordContext _context;

        public PasswordsController(PasswordContext context)
        {
            _context = context;
        }

        // GET: Passwords
        public async Task<IActionResult> Index()
        {
            var passwordContext = _context.Passwords.Include(p => p.Person);
            return View(await passwordContext.ToListAsync());
        }

        // GET: Passwords/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var password = await _context.Passwords
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.PasswordId == id);
            if (password == null)
            {
                return NotFound();
            }

            return View(password);
        }

        // GET: Passwords/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "FullName");
            return View();
        }

        // POST: Passwords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PasswordId,SiteURL,SitePassword,CreateDate,PersonId")] Password password)
        {
            if (ModelState.IsValid)
            {
                _context.Add(password);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "FullName", password.PersonId);
            return View(password);
        }

        // GET: Passwords/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var password = await _context.Passwords.FindAsync(id);
            if (password == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "FullName", password.PersonId);
            return View(password);
        }

        // POST: Passwords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PasswordId,SiteURL,SitePassword,CreateDate,PersonId")] Password password)
        {
            if (id != password.PasswordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(password);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasswordExists(password.PasswordId))
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
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "PersonId", password.PersonId);
            return View(password);
        }

        // GET: Passwords/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var password = await _context.Passwords
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.PasswordId == id);
            if (password == null)
            {
                return NotFound();
            }

            return View(password);
        }

        // POST: Passwords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var password = await _context.Passwords.FindAsync(id);
            _context.Passwords.Remove(password);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasswordExists(long id)
        {
            return _context.Passwords.Any(e => e.PasswordId == id);
        }
    }
}
