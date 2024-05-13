using System;
using System.Collections.Generic;

namespace Karta.Model;

public partial class VrstaPratecegSadrzaj
{
    public int IdVrstaPratecegSadrzaja { get; set; }

    public string NazivVrstePratecegSadrzaja { get; set; }

    public virtual ICollection<PrateciSadrzaj> PrateciSadrzaj { get; } = new List<PrateciSadrzaj>();
}
