using Karta.Model;
using System.Drawing;

namespace Karta.ViewModels
{
    public class DogadajTinaViewModel
    {
        public int IdDogadaj { get; set; }

        public string NazivDionica { get; set; }

        public string MeteoroloskiUvjeti { get; set; }

        public string OpisDogadaja { get; set; }

        public DateTime? VrijemeDogadaja { get; set; }
        public string Coordinates { get; set; }



    }
}