using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using exam.Data;
using exam.Models;

namespace exam.Controllers
{
    public class ExamsController : Controller
    {
        private readonly examContext _context;

        public ExamsController(examContext context)
        {
            _context = context;
        }

        // GET: Exams
        public async Task<IActionResult> Index()
        {
            var examContext = _context.Exams.Include(e => e.Subject);
            return View(await examContext.ToListAsync());
        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Exams == null)
            {
                return NotFound();
            }

            var exams = await _context.Exams
                .Include(e => e.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exams == null)
            {
                return NotFound();
            }

            return View(exams);
        }

        // GET: Exams/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FainalDegree,Date,Duration,SubjectId")] Exams exams)
        {
            //if (ModelState.IsValid)
            //{
            _context.Add(exams);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            // }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name", exams.SubjectId);
            return View(exams);
        }

        // GET: Exams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Exams == null)
            {
                return NotFound();
            }

            var exams = await _context.Exams.FindAsync(id);
            if (exams == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name", exams.SubjectId);
            return View(exams);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FainalDegree,Date,Duration,SubjectId")] Exams exams)
        {
            if (id != exams.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            try
            {
                _context.Update(exams);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamsExists(exams.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            // }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name", exams.SubjectId);
            return View(exams);
        }

        // GET: Exams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Exams == null)
            {
                return NotFound();
            }

            var exams = await _context.Exams
                .Include(e => e.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exams == null)
            {
                return NotFound();
            }

            return View(exams);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Exams == null)
            {
                return Problem("Entity set 'examContext.Exams'  is null.");
            }
            var exams = await _context.Exams.FindAsync(id);
            if (exams != null)
            {
                _context.Exams.Remove(exams);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamsExists(int id)
        {
            return (_context.Exams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
