using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tuincentrum.Models;


namespace Tuincentrum.Models
{
    
    public class SQLLeveranciersRepository : ILeveranciersRepository
    {
        private readonly MvctuinCentrumContext context;
        public SQLLeveranciersRepository(MvctuinCentrumContext context)
        {
            this.context = context;
        }

        public async Task<Leverancier> Add(Leverancier leverancier)
        {
            //throw new NotImplementedException();
            context.Leveranciers.Add(leverancier);
            await context.SaveChangesAsync();
            return leverancier;
        }

        public async Task<List<Leverancier>> GetLeveranciers()
        {
            //throw new NotImplementedException();
            return await context.Leveranciers.ToListAsync();
        }

        public async Task<Leverancier?> Delete(int id)
        {
            // throw new NotImplementedException();
            Leverancier? leverancier = context.Leveranciers.Find(id);
            if(leverancier != null)
            {
                context.Leveranciers.Remove(leverancier);
                await context.SaveChangesAsync();
            }
            return leverancier;
        }

        public async Task<Leverancier?> GetLeverancier(int id)
        {
            // throw new NotImplementedException();
            return await context.Leveranciers.FindAsync(id);
        }

        

        public async Task<Leverancier> Update(Leverancier gewijzigdeLeverancier)
        {
            //throw new NotImplementedException();
            context.Update(gewijzigdeLeverancier);
            await context.SaveChangesAsync();
            return gewijzigdeLeverancier;
        }
    }
}
