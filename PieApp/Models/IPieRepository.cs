using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieApp.Models
{
    public interface IPieRepository
    {
        //interface para o repositório MockPieRepository ***
        IEnumerable<Pie> GetAllPies();
        Pie GetPieById(int pieid);
    }
}
