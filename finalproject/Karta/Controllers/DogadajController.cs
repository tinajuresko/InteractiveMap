using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Karta.Extensions;
using Karta.Extensions.Selectors; 
using Karta.Model;
using Karta.ViewModels;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using GoogleApi.Entities.Search.Common;
using System.Globalization;

namespace Karta.Controllers
{
    
    public class DogadajController : Controller
    {
        private readonly KartaContext ctx;
        private readonly AppSettings appSettings;
        private readonly ILogger<DogadajController> logger;

        public DogadajController(KartaContext ctx, IOptionsSnapshot<AppSettings> options, ILogger<DogadajController> logger)
        {
            this.ctx = ctx;
            this.appSettings = options.Value;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int sort = 1, bool ascending = true)
        {
            /*var dogadaji = ctx.Dogadaj
                            .AsNoTracking()
                            .OrderBy(d => d.IdDogadaj)
                            .ToList();
            return View("Index", dogadaji);*/
            TimeZoneInfo cetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Zagreb"); //dodala

            int pagesize = appSettings.PageSize;

            var query = ctx.Dogadaj
                           .AsNoTracking();

            int count = query.Count();
            if (count == 0)
            {
                logger.LogInformation("Ne postoje dogadaji");
                TempData[Constants.Message] = "Ne postoji niti jedan događaj.";
                TempData[Constants.ErrorOccurred] = false;
                return RedirectToAction(nameof(Create));
            }

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

            var dogadaji = await query
                            .Select(d => new DogadajTinaViewModel
                            {
                                IdDogadaj = d.IdDogadaj,
                                VrijemeDogadaja = d.VrijemeDogadaja,
                                NazivDionica = d.IdDionicaNavigation.NazivDionica,
                                MeteoroloskiUvjeti = d.MeteoroloskiUvjeti,
                                OpisDogadaja = d.OpisDogadaja,
                            })
                            .Skip((page - 1) * pagesize)
                            .Take(pagesize)
                            .ToListAsync();

            var model = new DogadajViewModel
            {
                Dogadaji = dogadaji,
                PagingInfo = pagingInfo
            };

            return View(model);
        }
        /*public IActionResult Create()
        {
            
            return View("Create");
        }*/


        [HttpGet]
        public async Task<IActionResult> Edit(string id, int page = 1, int sort = 1, bool ascending = true)
        {
            var dogadaj = ctx.Dogadaj.AsNoTracking().Where(d => Convert.ToString(d.IdDogadaj) == id).SingleOrDefault();
            if (dogadaj == null)
            {
                logger.LogWarning("Ne postoji dogadaj s oznakom: {0} ", id);
                return NotFound("Ne postoji dogadaj s oznakom: " + id);
            }
            else
            {
                ViewBag.Page = page;
                ViewBag.Sort = sort;
                ViewBag.Ascending = ascending;
                await PrepareDropDownLists();
                return View(dogadaj);
            }
        }



        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, int page = 1, int sort = 1, bool ascending = true)
        {
            try
            {
                Dogadaj dogadaj = await ctx.Dogadaj
                                  .Where(d => Convert.ToString(d.IdDogadaj) == id)
                                  .FirstOrDefaultAsync();
                if (dogadaj == null)
                {
                    return NotFound("Neispravna oznaka dogadaja: " + id);
                }

                if (await TryUpdateModelAsync<Dogadaj>(dogadaj, "",
                     d => d.VrijemeDogadaja, d => d.IdDionica, d => d.MeteoroloskiUvjeti, d => d.OpisDogadaja
                ))
                {
                    ViewBag.Page = page;
                    ViewBag.Sort = sort;
                    ViewBag.Ascending = ascending;
                    try
                    {
                        await ctx.SaveChangesAsync();
                        TempData[Constants.Message] = "Događaj ažuriran.";
                        TempData[Constants.ErrorOccurred] = false;
                        return RedirectToAction(nameof(Index), new { page = page, sort = sort, ascending = ascending });
                    }
                    catch (Exception exc)
                    {
                        ModelState.AddModelError(string.Empty, exc.CompleteExceptionMessage());
                        await PrepareDropDownLists();
                        return View(dogadaj);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Podatke o događaju nije moguće povezati s forme");
                    await PrepareDropDownLists();
                    return View(dogadaj);
                }

            }
            catch (Exception exc)
            {
                TempData[Constants.Message] = exc.CompleteExceptionMessage();
                TempData[Constants.ErrorOccurred] = true;
                return RedirectToAction(nameof(Edit), id);
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string idDogadaj, int page = 1, int sort = 1, bool ascending = true)
        {
            var dogadaj = ctx.Dogadaj.Find(int.Parse(idDogadaj));
            if (dogadaj != null)
            {
                try
                {
                    string id = Convert.ToString(dogadaj.IdDogadaj);
                    ctx.Remove(dogadaj);
                    ctx.SaveChanges();
                    logger.LogInformation($"Događaj {id} uspješno obrisan");
                    TempData[Constants.Message] = $"Događaj {id} uspješno obrisan";
                    TempData[Constants.ErrorOccurred] = false;
                }
                catch (Exception exc)
                {
                    TempData[Constants.Message] = "Pogreška prilikom brisanja događaja: " + exc.CompleteExceptionMessage();
                    TempData[Constants.ErrorOccurred] = true;
                    logger.LogError("Pogreška prilikom brisanja događaja: " + exc.CompleteExceptionMessage());
                }
            }
            else
            {
                logger.LogWarning("Ne postoji događaj s oznakom: {0} ", idDogadaj);
                TempData[Constants.Message] = "Ne postoji događaj s oznakom: " + idDogadaj;
                TempData[Constants.ErrorOccurred] = true;
            }
            return RedirectToAction(nameof(Index), new { page = page, sort = sort, ascending = ascending });
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PrepareDropDownLists();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dogadaj dogadaj, string coordinates)
        {
            logger.LogTrace(JsonSerializer.Serialize(dogadaj));
            if (ModelState.IsValid)
            {
                try
                {
                    string[] coordinatesArray = coordinates.Split(',');
                    string latitude = coordinatesArray[0].Trim();
                    string longitude = coordinatesArray[1].Trim();
                    dogadaj.Coordinates = $"({longitude},{latitude})";

                    // check if the VrijemeDogadaja property has a value
                    if (dogadaj.VrijemeDogadaja.HasValue)
                    {
                        // set the DateTimeKind to UTC
                        /*dogadaj.VrijemeDogadaja = dogadaj.VrijemeDogadaja.Value.AddHours(-2);
                        dogadaj.VrijemeDogadaja = DateTime.SpecifyKind(dogadaj.VrijemeDogadaja.Value, DateTimeKind.Utc);*/

                        // Subtract 2 hours from the CET time, considering daylight saving time
                        DateTime cetTime = dogadaj.VrijemeDogadaja.Value;
                        TimeZoneInfo cetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Zagreb");

                        // Check if the CET time is within the daylight saving time period
                        bool isDaylightSaving = false;
                        DateTime startDst = TimeZoneInfo.ConvertTime(new DateTime(cetTime.Year, 3, 31), cetTimeZone);
                        DateTime endDst = TimeZoneInfo.ConvertTime(new DateTime(cetTime.Year, 10, 31), cetTimeZone);
                        if (cetTime >= startDst && cetTime < endDst)
                        {
                            isDaylightSaving = true;
                        }

                        // Subtract 2 hours and adjust for daylight saving time if necessary
                        dogadaj.VrijemeDogadaja = dogadaj.VrijemeDogadaja.Value.AddHours(-2);
                        if (!isDaylightSaving)
                        {
                            dogadaj.VrijemeDogadaja = dogadaj.VrijemeDogadaja.Value.AddHours(1);
                        }

                        // Convert the CET time to UTC and specify the DateTimeKind
                       // dogadaj.VrijemeDogadaja = TimeZoneInfo.ConvertTimeToUtc(dogadaj.VrijemeDogadaja.Value, cetTimeZone);
                        dogadaj.VrijemeDogadaja = DateTime.SpecifyKind(dogadaj.VrijemeDogadaja.Value, DateTimeKind.Utc);

                    }
                    int maxId = await ctx.Dogadaj.MaxAsync(d => (int?)d.IdDogadaj) ?? 0;

                    // increment the maximum value by one and set it as the value for the new entity
                    dogadaj.IdDogadaj = maxId + 1;
                    ctx.Add(dogadaj);
                    ctx.SaveChanges();
                    logger.LogInformation(new EventId(1000), $"Događaj {dogadaj.IdDogadaj} dodan.");

                    TempData[Constants.Message] = $"Događaj {dogadaj.IdDogadaj} dodan.";
                    TempData[Constants.ErrorOccurred] = false;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception exc)
                {
                    logger.LogError("Pogreška prilikom dodavanje novog događaja: {0}", exc.CompleteExceptionMessage());
                    ModelState.AddModelError(string.Empty, exc.CompleteExceptionMessage());
                    await PrepareDropDownLists();
                    return View(dogadaj);
                }
            }
            else
            {
                await PrepareDropDownLists();
                return View(dogadaj);
            }
        }

        private async Task PrepareDropDownLists()
        {
            var dionice = await ctx.Dionica
                                  .OrderBy(a => a.NazivDionica)
                                  .Select(a => new { a.NazivDionica, a.IdDionica })
                                  .ToListAsync();
            ViewBag.Dionice = new SelectList(dionice, "IdDionica", "NazivDionica");
        }

        [HttpGet]
        [ActionName("GetDogadajLocations")]
        public IActionResult GetDogadajLocations()
        {
            try
            {
                logger.LogInformation("GetDogadajLocations method called.");
                var dogadaji = ctx.Dogadaj
            .AsNoTracking()
            .Where(d => d.Coordinates != null)
            .Select(d => new
            {
                Latitude = double.Parse(d.Coordinates.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1].Trim('(', ')')),
                Longitude = double.Parse(d.Coordinates.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim('(', ')')),
                vrijemedogadaja = d.VrijemeDogadaja,
                dionica = d.IdDionicaNavigation.NazivDionica,
                meteoroloskiuvjeti = d.MeteoroloskiUvjeti,
                opis = d.OpisDogadaja
            })
            .ToList()
            .Select(d => new
            {
                d.Latitude,
                d.Longitude,
                d.vrijemedogadaja,
                d.dionica,
                d.meteoroloskiuvjeti,
                d.opis
            });

                logger.LogInformation("GetDogadajLocations method executed successfully.");

                return Json(dogadaji);
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, "An error occured in GetDogadajLocations.");
                return StatusCode(500, "An error occured while processing the request.");
            }
            
        }






    }
}
