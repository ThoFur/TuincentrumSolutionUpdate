using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Tuincentrum.Models;

public partial class Soort
{
    [Display(Name ="Soort")]
    public int SoortNr { get; set; }
    [Display(Name = "SoortNaam")]
    [StringLength(50)]
    public string Naam { get; set; } = null!;
    [Display(Name = "MagazijnNr")]
    public byte MagazijnNr { get; set; }
    [Display(Name ="Planten")]
    public virtual ICollection<Plant> Planten { get; set; } = new List<Plant>();
}
