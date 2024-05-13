using System;
using System.Collections.Generic;

namespace Karta.Model;

public partial class Odmoriste
{
    public int IdOdmoriste { get; set; }

    public string NazivOdmoriste { get; set; }

    public int IdAutocesta { get; set; }

    public string Smjer { get; set; }

    public string OdmoristeKoordinateNs { get; set; }

    public string OdmoristeKoordinateEw { get; set; }

    public virtual Autocesta IdAutocestaNavigation { get; set; }

    public virtual ICollection<PrateciSadrzaj> PrateciSadrzaj { get; } = new List<PrateciSadrzaj>();
}
