using System;
using System.Collections.Generic;

namespace Karta.Model;

public partial class PrateciSadrzaj
{
    public int IdPratecegSadrzaja { get; set; }

    public string NazivPratecegSadrzaja { get; set; }

    public int IdOdmoriste { get; set; }

    public int IdVrstaPratecegSadrzaja { get; set; }

    public TimeSpan? RadnoVrijemeOd { get; set; }

    public TimeSpan? RadnoVrijemeDo { get; set; }

    public virtual Odmoriste IdOdmoristeNavigation { get; set; }

    public virtual VrstaPratecegSadrzaj IdVrstaPratecegSadrzajaNavigation { get; set; }
}
