using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Karta.Model;

namespace Karta.Controllers
{
    public class PrateciSadrzajController : Controller
    {

        private readonly KartaContext ctx;
        private readonly ILogger<PrateciSadrzajController> logger;
        private readonly AppSettings appSettings;

        public PrateciSadrzajController(KartaContext ctx, IOptionsSnapshot<AppSettings> options, ILogger<PrateciSadrzajController> logger)
        {
            this.ctx = ctx;
            this.appSettings = options.Value;
            this.logger = logger;
        }

        [HttpGet]
        [ActionName("GetBenzinskePostaje")]
        public IActionResult GetBenzinskePostaje()
        {
            try
            {
                logger.LogInformation("GetBenzinskePostaje method called.");
                

                var benzinskePostaje = ctx.PrateciSadrzaj
                    .AsNoTracking()
                    .Where(p => p.IdVrstaPratecegSadrzaja == 1 )
                    .Select(p => new
                    {
                        latitude = double.Parse(p.IdOdmoristeNavigation.OdmoristeKoordinateNs),
                        longitude = double.Parse(p.IdOdmoristeNavigation.OdmoristeKoordinateEw),
                        radnood = p.RadnoVrijemeOd,
                        radnodo = p.RadnoVrijemeDo,
                        ime = p.NazivPratecegSadrzaja
                        
                    })
                    .ToList()
                    .Select(p => new {
                        p.latitude,
                        p.longitude,
                        p.radnood,
                        p.radnodo,
                        p.ime
                    });

                logger.LogInformation("GetBenzinskePostaje method executed successfully.");

                return Json(benzinskePostaje);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetBenzinskePostaje: {ErrorMessage}", ex.Message);
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet]
        [ActionName("GetRestorane")]
        public IActionResult GetRestorane()
        {
            try
            {
                logger.LogInformation("Getrestorane method called.");

                var restorani = ctx.PrateciSadrzaj
                    .AsNoTracking()
                    .Where(p => p.IdVrstaPratecegSadrzaja == 2)
                    .Select(p => new
                    {
                        latitude = p.IdOdmoristeNavigation.OdmoristeKoordinateNs,
                        longitude = p.IdOdmoristeNavigation.OdmoristeKoordinateEw,
                        radnood = p.RadnoVrijemeOd,
                        radnodo = p.RadnoVrijemeDo,
                        ime = p.NazivPratecegSadrzaja

                    })
                    .ToList()
                    .Select(p => new {
                        p.latitude,
                        p.longitude,
                        p.radnood,
                        p.radnodo,
                        p.ime
                    });

                logger.LogInformation("GetRestorane method executed successfully.");

                return Json(restorani);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetRestorane.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet]
        [ActionName("GetIgralista")]
        public IActionResult GetIgralista()
        {
            try
            {
                logger.LogInformation("GetIgralista method called.");

                var igralista = ctx.PrateciSadrzaj
                    .AsNoTracking()
                    .Where(p => p.IdVrstaPratecegSadrzaja == 3)
                    .Select(p => new
                    {
                        latitude = p.IdOdmoristeNavigation.OdmoristeKoordinateNs,
                        longitude = p.IdOdmoristeNavigation.OdmoristeKoordinateEw,
                        radnood = p.RadnoVrijemeOd,
                        radnodo = p.RadnoVrijemeDo,
                        ime = p.NazivPratecegSadrzaja

                    })
                    .ToList()
                    .Select(p => new { 
                        p.latitude,
                        p.longitude,
                        p.radnood,
                        p.radnodo,
                        p.ime
                    });

                logger.LogInformation("GetIgralista method executed successfully.");

                return Json(igralista);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetIgralista.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpGet]
        [ActionName("GetTrgovine")]
        public IActionResult GetTrgovine()
        {
            try
            {
                logger.LogInformation("GetTrgovine method called.");

                var trgovine = ctx.PrateciSadrzaj
                    .AsNoTracking()
                    .Where(p => p.IdVrstaPratecegSadrzaja == 4)
                    .Select(p => new
                    {
                        latitude = p.IdOdmoristeNavigation.OdmoristeKoordinateNs,
                        longitude = p.IdOdmoristeNavigation.OdmoristeKoordinateEw,
                        radnood = p.RadnoVrijemeOd,
                        radnodo = p.RadnoVrijemeDo,
                        ime = p.NazivPratecegSadrzaja

                    })
                    .ToList()
                    .Select(p => new { 
                        p.latitude,
                        p.longitude,
                        p.radnood,
                        p.radnodo,
                        p.ime
                    });

                logger.LogInformation("GetTrgovine method executed successfully.");

                return Json(trgovine);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetTrgovine.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet]
        [ActionName("GetPunionice")]
        public IActionResult GetPunionice()
        {
            try
            {
                logger.LogInformation("GetPunionice method called.");

                var punionice = ctx.PrateciSadrzaj
                    .AsNoTracking()
                    .Where(p => p.IdVrstaPratecegSadrzaja == 5)
                    .Select(p => new
                    {
                        latitude = p.IdOdmoristeNavigation.OdmoristeKoordinateNs,
                        longitude = p.IdOdmoristeNavigation.OdmoristeKoordinateEw,
                        radnood = p.RadnoVrijemeOd,
                        radnodo = p.RadnoVrijemeDo,
                        ime = p.NazivPratecegSadrzaja

                    })
                    .ToList()
                    .Select(p => new { 
                        p.latitude,
                        p.longitude,
                        p.radnood,
                        p.radnodo,
                        p.ime
                    });

                logger.LogInformation("GetPunionice method executed successfully.");

                return Json(punionice);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetPunionice.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpGet]
        [ActionName("GetCaffe")]
        public IActionResult GetCaffe()
        {
            try
            {
                logger.LogInformation("GetCaffe method called.");

                var caffe = ctx.PrateciSadrzaj
                    .AsNoTracking()
                    .Where(p => p.IdVrstaPratecegSadrzaja == 6)
                    .Select(p => new
                    {
                        latitude = p.IdOdmoristeNavigation.OdmoristeKoordinateNs,
                        longitude = p.IdOdmoristeNavigation.OdmoristeKoordinateEw,
                        radnood = p.RadnoVrijemeOd,
                        radnodo = p.RadnoVrijemeDo,
                        ime = p.NazivPratecegSadrzaja

                    })
                    .ToList()
                    .Select(p => new { 
                        p.latitude,
                        p.longitude,
                        p.radnood,
                        p.radnodo,
                        p.ime
                    });

                logger.LogInformation("GetCaffe method executed successfully.");

                return Json(caffe);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetCaffe.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet]
        [ActionName("GetSpavanje")]
        public IActionResult GetSpavanje()
        {
            try
            {
                logger.LogInformation("GetSpavanje method called.");

                var spavanja = ctx.PrateciSadrzaj
                    .AsNoTracking()
                    .Where(p => p.IdVrstaPratecegSadrzaja == 7)
                    .Select(p => new
                    {
                        latitude = p.IdOdmoristeNavigation.OdmoristeKoordinateNs,
                        longitude = p.IdOdmoristeNavigation.OdmoristeKoordinateEw,
                        radnood = p.RadnoVrijemeOd,
                        radnodo = p.RadnoVrijemeDo,
                        ime = p.NazivPratecegSadrzaja

                    })
                    .ToList()
                    .Select(p => new { 
                        p.latitude,
                        p.longitude,
                        p.radnood,
                        p.radnodo,
                        p.ime
                    });

                logger.LogInformation("GetSpavanje method executed successfully.");

                return Json(spavanja);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetSpavanje.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpGet]
        [ActionName("GetToalet")]
        public IActionResult GetToalet()
        {
            try
            {
                logger.LogInformation("GetToalet method called.");

                var toaleti = ctx.PrateciSadrzaj
                    .AsNoTracking()
                    .Where(p => p.IdVrstaPratecegSadrzaja == 8)
                    .Select(p => new
                    {
                        latitude = p.IdOdmoristeNavigation.OdmoristeKoordinateNs,
                        longitude = p.IdOdmoristeNavigation.OdmoristeKoordinateEw,
                        radnood = p.RadnoVrijemeOd,
                        radnodo = p.RadnoVrijemeDo,
                        ime = p.NazivPratecegSadrzaja

                    })
                    .ToList()
                    .Select(p => new { 
                        p.latitude,
                        p.longitude,
                        p.radnood,
                        p.radnodo,
                        p.ime
                    });

                logger.LogInformation("GetToalet method executed successfully.");

                return Json(toaleti);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetToalet.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpGet]
        [ActionName("GetTus")]
        public IActionResult GetTus()
        {
            try
            {
                logger.LogInformation("GetTus method called.");

                var tus = ctx.PrateciSadrzaj
                    .AsNoTracking()
                    .Where(p => p.IdVrstaPratecegSadrzaja == 9)
                    .Select(p => new
                    {
                        latitude = p.IdOdmoristeNavigation.OdmoristeKoordinateNs,
                        longitude = p.IdOdmoristeNavigation.OdmoristeKoordinateEw,
                        radnood = p.RadnoVrijemeOd,
                        radnodo = p.RadnoVrijemeDo,
                        ime = p.NazivPratecegSadrzaja

                    })
                    .ToList()
                    .Select(p => new { 
                        p.latitude,
                        p.longitude,
                        p.radnood,
                        p.radnodo,
                        p.ime
                    });

                logger.LogInformation("GetTus method executed successfully.");

                return Json(tus);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetTus.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet]
        [ActionName("GetParking")]
        public IActionResult GetParking()
        {
            try
            {
                logger.LogInformation("GetParking method called.");

                var parking = ctx.PrateciSadrzaj
                    .AsNoTracking()
                    .Where(p => p.IdVrstaPratecegSadrzaja == 10)
                    .Select(p => new
                    {
                        latitude = p.IdOdmoristeNavigation.OdmoristeKoordinateNs,
                        longitude = p.IdOdmoristeNavigation.OdmoristeKoordinateEw,
                        radnood = p.RadnoVrijemeOd,
                        radnodo = p.RadnoVrijemeDo,
                        ime = p.NazivPratecegSadrzaja

                    })
                    .ToList()
                    .Select(p => new { 
                        p.latitude,
                        p.longitude,
                        p.radnood,
                        p.radnodo,
                        p.ime
                    });

                logger.LogInformation("GetParking method executed successfully.");

                return Json(parking);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetParking.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet]
        [ActionName("GetMjenjacnica")]
        public IActionResult GetMjenjacnica()
        {
            try
            {
                logger.LogInformation("GetMjenjacnica method called.");

                var mjenjacnice = ctx.PrateciSadrzaj
                    .AsNoTracking()
                    .Where(p => p.IdVrstaPratecegSadrzaja == 11)
                    .Select(p => new
                    {
                        latitude = p.IdOdmoristeNavigation.OdmoristeKoordinateNs,
                        longitude = p.IdOdmoristeNavigation.OdmoristeKoordinateEw,
                        radnood = p.RadnoVrijemeOd,
                        radnodo = p.RadnoVrijemeDo,
                        ime = p.NazivPratecegSadrzaja

                    })
                    .ToList()
                    .Select(p => new { 
                        p.latitude,
                        p.longitude,
                        p.radnood,
                        p.radnodo,
                        p.ime
                    });

                logger.LogInformation("GetMjenjacnica method executed successfully.");

                return Json(mjenjacnice);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetMjenjacnica.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet]
        [ActionName("GetBankomat")]
        public IActionResult GetBankomat()
        {
            try
            {
                logger.LogInformation("GetBankomat method called.");

                var bankomati = ctx.PrateciSadrzaj
                    .AsNoTracking()
                    .Where(p => p.IdVrstaPratecegSadrzaja == 12)
                    .Select(p => new
                    {
                        latitude = p.IdOdmoristeNavigation.OdmoristeKoordinateNs,
                        longitude = p.IdOdmoristeNavigation.OdmoristeKoordinateEw,
                        radnood = p.RadnoVrijemeOd,
                        radnodo = p.RadnoVrijemeDo,
                        ime = p.NazivPratecegSadrzaja

                    })
                    .ToList()
                    .Select(p => new { 
                        p.latitude,
                        p.longitude,
                        p.radnood,
                        p.radnodo,
                        p.ime
                    });

                logger.LogInformation("GetBankomat method executed successfully.");

                return Json(bankomati);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetBankomat.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet]
        [ActionName("GetAutopraonica")]
        public IActionResult GetAutopraonica()
        {
            try
            {
                logger.LogInformation("GetAutopraonica method called.");

                var autopraonice = ctx.PrateciSadrzaj
                    .AsNoTracking()
                    .Where(p => p.IdVrstaPratecegSadrzaja == 13)
                    .Select(p => new
                    {
                        latitude = p.IdOdmoristeNavigation.OdmoristeKoordinateNs,
                        longitude = p.IdOdmoristeNavigation.OdmoristeKoordinateEw,
                        radnood = p.RadnoVrijemeOd,
                        radnodo = p.RadnoVrijemeDo,
                        ime = p.NazivPratecegSadrzaja

                    })
                    .ToList()
                    .Select(p => new { 
                        p.latitude,
                        p.longitude,
                        p.radnood,
                        p.radnodo,
                        p.ime
                    });

                logger.LogInformation("GetAutopraonica method executed successfully.");

                return Json(autopraonice);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetAutopraonica.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
