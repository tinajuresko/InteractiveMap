using Karta.Model;

namespace Karta.ViewModels
{
    public class OdmoristaViewModel
    {
        public IEnumerable<OdmoristeViewModel> Odmorista { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
