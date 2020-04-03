using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie_Database_MVC.Data;
using Movie_Database_MVC.Models;

namespace Movie_Database_MVC.Controllers
{
    public class MovieCastAssignmentsController : Controller
    {
        private readonly Movie_Database_DBContext _context;

        public MovieCastAssignmentsController(Movie_Database_DBContext context)
        {
            _context = context;
        }

        // GET: MovieCastAssignments
        public async Task<IActionResult> Index()
        {
            var movie_Database_DBContext = _context.MovieCastAssignment.Include(m => m.Actor).Include(m => m.Movie);
            return View(await movie_Database_DBContext.ToListAsync());
        }

        // GET: MovieCastAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCastAssignment = await _context.MovieCastAssignment
                .Include(m => m.Actor)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieCastAssignment == null)
            {
                return NotFound();
            }

            return View(movieCastAssignment);
        }

        // GET: MovieCastAssignments/Create
        public IActionResult Create()
        {
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Id");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id");
            return View();
        }

        // POST: MovieCastAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActorId,MovieId")] MovieCastAssignment movieCastAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieCastAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Id", movieCastAssignment.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id", movieCastAssignment.MovieId);
            return View(movieCastAssignment);
        }

        // GET: MovieCastAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCastAssignment = await _context.MovieCastAssignment.FindAsync(id);
            if (movieCastAssignment == null)
            {
                return NotFound();
            }
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Id", movieCastAssignment.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id", movieCastAssignment.MovieId);
            return View(movieCastAssignment);
        }

        // POST: MovieCastAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActorId,MovieId")] MovieCastAssignment movieCastAssignment)
        {
            if (id != movieCastAssignment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieCastAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieCastAssignmentExists(movieCastAssignment.Id))
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
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Id", movieCastAssignment.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id", movieCastAssignment.MovieId);
            return View(movieCastAssignment);
        }

        // GET: MovieCastAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCastAssignment = await _context.MovieCastAssignment
                .Include(m => m.Actor)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieCastAssignment == null)
            {
                return NotFound();
            }

            return View(movieCastAssignment);
        }

        // POST: MovieCastAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieCastAssignment = await _context.MovieCastAssignment.FindAsync(id);
            _context.MovieCastAssignment.Remove(movieCastAssignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieCastAssignmentExists(int id)
        {
            return _context.MovieCastAssignment.Any(e => e.Id == id);
        }
    }
}
