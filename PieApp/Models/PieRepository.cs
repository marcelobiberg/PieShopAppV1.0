using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieApp.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        public PieRepository(AppDbContext appDbContex)
        {
            _appDbContext = appDbContex;
        } 

        public IEnumerable<Pie> GetAllPies()
        {
            return _appDbContext.Pies;
        }

        public Pie GetPieById(int pieid)
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieid); 
        }
    }
}
