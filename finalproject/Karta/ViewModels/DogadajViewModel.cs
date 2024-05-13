using Karta.Model;
using Karta.ViewModels;
using System.Collections.Generic;

namespace Karta.ViewModels
{
    public class DogadajViewModel
    {
        public IEnumerable<DogadajTinaViewModel> Dogadaji { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}