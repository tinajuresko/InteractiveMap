using Karta.Model;
namespace Karta.ViewModels
{
    public class OdmoristeViewModel
    {
        public int IdOdmoriste { get; set; }
        public string NazivOdmorista { get; set; }
        public string NazivAutocesta { get; set; }

        public string Smjer { get; set; }


        public string OdmoristeKoordinateNs { get; set; }

        public string OdmoristeKoordinateEw { get; set; }

        public ICollection<PrateciSadrzaj> PrateciSadrzaji { get; set; }
        //public ICollection<PrateciSadrzajViewModel> DetaljiPrateciSadrzaji { get; set; }
    }
}
