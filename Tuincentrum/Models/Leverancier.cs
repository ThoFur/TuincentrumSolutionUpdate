using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tuincentrum.Models;

public partial class Leverancier
{
    public int LevNr { get; set; }

    public string Naam { get; set; } = null!;

    public string Adres { get; set; } = null!;

    public string PostNr { get; set; } = null!;

    public string Woonplaats { get; set; } = null!;

    public virtual ICollection<Plant> Planten { get; set; } = new List<Plant>();
}
