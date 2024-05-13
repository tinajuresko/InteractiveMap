using System;
namespace Karta.ViewModels
{
    public class NaplatnePostajeViewModel
    {
        public IEnumerable<NaplatnaPostajaViewModel> NaplatnePostaje { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}

