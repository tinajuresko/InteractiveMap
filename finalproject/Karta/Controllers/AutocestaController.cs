using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Karta.Extensions;
using Karta.Extensions.Selectors;
using Karta.Model;
using Karta.ViewModels;
using System.Text.Json;

namespace Karta.Controllers
{
    public class AutocestaController : Controller
    {
        private readonly KartaContext ctx;
        private readonly ILogger<AutocestaController> logger;
        private readonly AppSettings appSettings;

        public AutocestaController(KartaContext ctx, IOptionsSnapshot<AppSettings> options, ILogger<AutocestaController> logger)
        {
            this.ctx = ctx;
            this.logger = logger;
            this.appSettings = options.Value;
        }

        public IActionResult Index(int page = 1, int sort = 1, bool ascending = true)
        {
            int pagesize = appSettings.PageSize;

            var query = ctx.Autocesta
                           .AsNoTracking();

            int count = query.Count();
           

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                Sort = sort,
                Ascending = ascending,
                ItemsPerPage = pagesize,
                TotalItems = count
            };
            if (page < 1 || page > pagingInfo.TotalPages)
            {
                return RedirectToAction(nameof(Index), new { page = 1, sort, ascending });
            }

            query = query.ApplySort(sort, ascending);

            var autoceste = query
                        .Select(a => new AutocestaViewModel
                        {
                            IdAutocesta = a.IdAutocesta,
                            NazivAutocesta = a.NazivAutocesta,
                            NazivKoncesionar = a.IdKoncesionarNavigation.NazivKoncesionar
                        })
                        .Skip((page - 1) * pagesize)
                        .Take(pagesize)
                        .ToList();

            var model = new AutocesteViewModel
            {
                Autoceste = autoceste,
                PagingInfo = pagingInfo
            };

            return View(model);
        }

       

        private async Task PrepareDropDownLists()
        {
            var koncesionari = await ctx.Koncesionar
                                  .OrderBy(k => k.NazivKoncesionar)
                                  .Select(k => new { k.NazivKoncesionar, k.IdKoncesionar })
                                  .ToListAsync();
            ViewBag.Koncesionari = new SelectList(koncesionari, nameof(Koncesionar.IdKoncesionar), nameof(Koncesionar.NazivKoncesionar));
        }

      
    }
}