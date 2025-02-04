using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tuincentrum.Models;


namespace Tuincentrum.Models
{
    public interface ILeveranciersRepository
    {
        Task<Leverancier?> GetLeverancier(int id);
        Task<List<Leverancier>> GetLeveranciers();
        Task<Leverancier> Add(Leverancier leverancier);
        Task<Leverancier> Update(Leverancier gewijzigdeLeverancier);
        Task<Leverancier?> Delete(int id);
    }
}
