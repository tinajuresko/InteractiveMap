using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Karta.Model;
using Karta.ViewModels;
using Karta.Extensions.Selectors;
using System.Drawing.Printing;
using Karta.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;


namespace Karta.Controllers
{
    public class NaplatnaPostajaController : Controller
    {
        private readonly KartaContext ctx;
        private readonly AppSettings appData;

        public NaplatnaPostajaController(KartaContext ctx, IOptionsSnapshot<AppSettings> options)
        {
            this.ctx = ctx;
            appData = options.Value;
        }

        public async Task<IActionResult> Index(int page = 1, int sort = 1, bool ascending = true)
        {
            int pagesize = appData.PageSize;

            var query = ctx.NaplatnaPostaja.AsNoTracking();

            int count = query.Count();
           

            var pagingInfo = new PagingInfo
            {
                ItemsPerPage = pagesize,
                TotalItems = count,
                CurrentPage = page,
                Ascending = ascending,
                Sort = sort
            };



            var naplatnas = await query
                          .Select(p => new NaplatnaPostajaViewModel
                          {
                              IdNaplatnaPostaja = p.IdNaplatnaPostaja,
                              NazivNaplatnaPostaja = p.NazivNaplatnaPostaja,
                              NazivAutocesta = p.IdAutocestaNavigation.NazivAutocesta,
                              NaplatnaPostajaKoordinateNs = p.NaplatnaPostajaKoordinateNs,
                              NaplatnaPostajaKoordinateEw = p.NaplatnaPostajaKoordinateEw,
                              Kontakt = p.Kontakt
                          })
                          .Skip((page - 1) * pagesize)
                          .Take(pagesize)
                          .ToListAsync();

            var model = new NaplatnePostajeViewModel
            {
                NaplatnePostaje = naplatnas,
                PagingInfo = pagingInfo
            };

            return View(model);
        }
        [HttpGet]
        [ActionName("GetNaplatnaPostajaData")]
        public IActionResult GetNaplatnaPostajaData(string naplatnaPostajaIds)
        {
            if (string.IsNullOrEmpty(naplatnaPostajaIds))
            {
                return BadRequest("No toll station IDs provided.");
            }

            var ids = naplatnaPostajaIds.Split(',').Select(int.Parse).ToList();

            var naplatnaPostajaData = ctx.NaplatnaPostaja
                .AsNoTracking()
                .Where(p => ids.Contains(p.IdNaplatnaPostaja))
                .Select(p => new
                {
                    latitude = double.Parse(p.NaplatnaPostajaKoordinateNs),
                    longitude = double.Parse(p.NaplatnaPostajaKoordinateEw),
                    kontakt = p.Kontakt,
                    autocesta = p.IdAutocestaNavigation.NazivAutocesta
                })
                .ToList();

            return Json(naplatnaPostajaData);
        }




    }
}