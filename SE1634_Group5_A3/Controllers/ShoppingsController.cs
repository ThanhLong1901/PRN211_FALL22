using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SE1634_Group5_A3.Models;

namespace SE1634_Group5_A3.Controllers
{
    public class ShoppingsController : Controller
    {
        private readonly MusicStoreContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly PageList<Album> _albumsPage;


        public ShoppingsController(MusicStoreContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        //Get: Albums + Genre name + Find by title
        public async Task<IActionResult> Index(int genreID, string currentTitle)
        {
            //Combox
            List<SelectListItem> genres = new SelectList(_context.Genres, "GenreId", "Name", genreID).ToList();
            genres.Insert(0, new SelectListItem { Value = "0", Text = "All" });
            ViewData["GenreIDs"] = genres;

            //Search
            var musicStoreContext = _context.Albums.Include(a => a.Artist).Include(a => a.Genre)
                .Where(a => a.GenreId == (genreID == 0 ? a.GenreId : genreID)
                && a.Title.Contains(currentTitle ?? ""));

            ViewData["CurrentTitle"] = currentTitle;
            return View(await musicStoreContext.ToListAsync());
        }

        //public async Task<IActionResult> Index(int pageNumber = 1)
        //{
        //    return View(await PageList<Album>.CreateAsync(_context.Albums, pageNumber, 3));
        //}

    }
}
