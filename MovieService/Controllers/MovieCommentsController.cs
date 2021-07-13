using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieService.Data;
using MovieService.Models;
using MovieService.ViewModels;

namespace MovieService.Controllers
{
    public class MovieCommentsController : Controller
    {
        private readonly MovieServiceContext _context;

        public MovieCommentsController(MovieServiceContext context)
        {
            _context = context;
        }

        // GET: MovieComments
        public async Task<IActionResult> Index()
        {
            var movieServiceContext = _context.MovieComments.Include(m => m.Movies);
            return View(await movieServiceContext.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(MovieCommentViewModel vm)
        {
            var comment = vm.Comment;
            var moviesID = vm.MoviesID;
            var rating = vm.Rating;

            MovieComment artComment = new MovieComment()
            {
                MoviesID = moviesID,
                Comments = comment,
                Rating = rating,
                PublishedDate = DateTime.Now
            };

            _context.MovieComments.Add(artComment);
            _context.SaveChanges();

            return RedirectToAction("Comment", "Movies", new { id = moviesID });
        }

        // GET: MovieComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieComment = await _context.MovieComments
                .Include(m => m.Movies)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movieComment == null)
            {
                return NotFound();
            }

            return View(movieComment);
        }

        // GET: MovieComments/Create
        public IActionResult Create()
        {
            ViewData["MoviesID"] = new SelectList(_context.Movies, "ID", "ID");
            return View();
        }

        // POST: MovieComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Comments,PublishedDate,MoviesID,Rating")] MovieComment movieComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MoviesID"] = new SelectList(_context.Movies, "ID", "ID", movieComment.MoviesID);
            return View(movieComment);
        }

        // GET: MovieComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieComment = await _context.MovieComments.FindAsync(id);
            if (movieComment == null)
            {
                return NotFound();
            }
            ViewData["MoviesID"] = new SelectList(_context.Movies, "ID", "ID", movieComment.MoviesID);
            return View(movieComment);
        }

        // POST: MovieComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Comments,PublishedDate,MoviesID,Rating")] MovieComment movieComment)
        {
            if (id != movieComment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieCommentExists(movieComment.ID))
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
            ViewData["MoviesID"] = new SelectList(_context.Movies, "ID", "ID", movieComment.MoviesID);
            return View(movieComment);
        }

        // GET: MovieComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieComment = await _context.MovieComments
                .Include(m => m.Movies)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movieComment == null)
            {
                return NotFound();
            }

            return View(movieComment);
        }

        // POST: MovieComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieComment = await _context.MovieComments.FindAsync(id);
            _context.MovieComments.Remove(movieComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieCommentExists(int id)
        {
            return _context.MovieComments.Any(e => e.ID == id);
        }
    }
}
