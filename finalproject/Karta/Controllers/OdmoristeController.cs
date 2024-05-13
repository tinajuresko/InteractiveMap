using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Karta.Model;
using Karta.ViewModels;
using Karta.Extensions.Selectors;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Karta.Extensions;

namespace Karta.Controllers
{
    public class OdmoristeController : Controller
    {
        private readonly KartaContext ctx;
        private readonly ILogger<OdmoristeController> logger;
        private readonly AppSettings appSettings;

        public OdmoristeController(KartaContext ctx, IOptionsSnapshot<AppSettings> options, ILogger<OdmoristeController> logger)
        {
            this.ctx = ctx;
            this.appSettings = options.Value;
            this.logger = logger;
        }

        public async Task<IActionResult> Index(string filter, int page = 1, int sort = 1, bool ascending = true)
        {


            int pagesize = appSettings.PageSize;

            var query = ctx.Odmoriste.AsNoTracking();

            #region Apply filter
            OdmoristeFilter of = OdmoristeFilter.FromString(filter);
            if (!of.IsEmpty())
            {
                //TODO dodati funkcionalnosti filter-a
            }
            #endregion 

            int count = await query.CountAsync();

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                Sort = sort,
                Ascending = ascending,
                ItemsPerPage = pagesize,
                TotalItems = count
            };

            if (count > 0 && (page < 1 || page > pagingInfo.TotalPages))
            {
                return RedirectToAction(nameof(Index), new { page = 1, sort, ascending, filter });
            }

            query = query.ApplySort(sort, ascending);

            var odmorista = query.Select(o => new OdmoristeViewModel
            {
                IdOdmoriste = o.IdOdmoriste,
                NazivOdmorista = o.NazivOdmoriste,
                NazivAutocesta = o.IdAutocestaNavigation.NazivAutocesta,
                Smjer = o.Smjer,
                OdmoristeKoordinateNs = o.OdmoristeKoordinateNs,
                OdmoristeKoordinateEw = o.OdmoristeKoordinateEw,
                PrateciSadrzaji = o.PrateciSadrzaj
            })
                                 .Skip((page - 1) * pagesize)
                                 .Take(pagesize)
                                 .ToList();


            var model = new OdmoristaViewModel
            {
                Odmorista = odmorista,
                PagingInfo = pagingInfo,
            };

            return View(model);
        }




        private async Task PrepareDropDownLists()
        {
            var primjer = await ctx.Dionica.OrderBy(d => d.NazivDionica)
                                            .Select(d => new { d.NazivDionica, d.IdDionica })
                                            .FirstOrDefaultAsync();
            var dionice = await ctx.Dionica
                                    .OrderBy(d => d.NazivDionica)
                                  .Select(d => new { d.NazivDionica, d.IdDionica })
                                  .ToListAsync();

            ViewBag.Dionice = new SelectList(dionice, nameof(primjer.IdDionica), nameof(primjer.NazivDionica));
        }


    }
}
