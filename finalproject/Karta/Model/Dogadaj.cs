using System;
using System.Collections.Generic;
using System.Drawing;

namespace Karta.Model;

public partial class Dogadaj
{
    public int IdDogadaj { get; set; }

    public int IdDionica { get; set; }

    public string MeteoroloskiUvjeti { get; set; }

    public string OpisDogadaja { get; set; }
    public string Coordinates { get; set; }

    public DateTime? VrijemeDogadaja { get; set; }

    public virtual Dionica IdDionicaNavigation { get; set; }

}
