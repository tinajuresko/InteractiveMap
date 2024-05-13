using Karta.Model;
using System.Collections.Generic;

namespace Karta.ViewModels
{
    public class AutocesteViewModel
    {
        public IEnumerable<AutocestaViewModel> Autoceste { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
