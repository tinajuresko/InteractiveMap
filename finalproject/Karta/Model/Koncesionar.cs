using System;
using System.Collections.Generic;

namespace Karta.Model;

public partial class Koncesionar
{
    public int IdKoncesionar { get; set; }

    public string NazivKoncesionar { get; set; }  

    public string Oibkoncesionar { get; set; }

    public string TipKoncesionar { get; set; }

    public string Adresa { get; set; }

    public string NazivMjesto { get; set; }

    public string Tel { get; set; }

    public string Fax { get; set; }

    public string Email { get; set; }

    public string WebUrl { get; set; }

    public virtual ICollection<Autocesta> Autocesta { get; } = new List<Autocesta>();
}
