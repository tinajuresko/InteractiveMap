using System;
using System.Collections.Generic;

namespace Karta.Model;

public partial class Dionica
{
    public int IdDionica { get; set; }

    public int IdAutocesta { get; set; }

    public string NazivDionica { get; set; }

    public decimal Kilometraža { get; set; }

    public int BrojTraka { get; set; }

    public virtual ICollection<Dogadaj> Dogadaj { get; } = new List<Dogadaj>();

    public virtual Autocesta IdAutocestaNavigation { get; set; }
}
