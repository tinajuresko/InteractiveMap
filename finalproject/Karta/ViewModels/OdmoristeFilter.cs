using Microsoft.AspNetCore.Mvc.Filters;

namespace Karta.ViewModels
{
    public class OdmoristeFilter : IPageFilter
    {

        public bool IsEmpty()
        {

            return true;
        }

        public static OdmoristeFilter FromString(string s)
        {

            return new OdmoristeFilter();
        }
    }
}
