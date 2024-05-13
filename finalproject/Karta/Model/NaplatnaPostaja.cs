using System;
using System.Collections.Generic;

namespace Karta.Model;

public partial class NaplatnaPostaja
{
    public int IdNaplatnaPostaja { get; set; }

    public int IdAutocesta { get; set; }

    public string NazivNaplatnaPostaja { get; set; }

    public string NaplatnaPostajaKoordinateNs { get; set; }

    public string NaplatnaPostajaKoordinateEw { get; set; }

    public string Kontakt { get; set; }

    public virtual Autocesta IdAutocestaNavigation { get; set; }
    
}
