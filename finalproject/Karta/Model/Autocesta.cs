using System;
using System.Collections.Generic;

namespace Karta.Model;

public partial class Autocesta
{
    public int IdAutocesta { get; set; }

    public string NazivAutocesta { get; set; }

    public int IdKoncesionar { get; set; }

    public virtual ICollection<Dionica> Dionica { get; } = new List<Dionica>();

    public virtual Koncesionar IdKoncesionarNavigation { get; set; }

    public virtual ICollection<Odmoriste> Odmoriste { get; } = new List<Odmoriste>();

    public virtual ICollection<NaplatnaPostaja> NaplatnaPostaja { get; } = new List<NaplatnaPostaja>();
}
