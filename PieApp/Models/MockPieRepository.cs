using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieApp.Models
{
    //Mock in english = simulado, falso, v = ridicularizar Oo
    public class MockPieRepository : IPieRepository
    {
        //cria lista de Pie empty
        private List<Pie> _pies;

        //constructor inicia lista de Pie privada
        public MockPieRepository()
        {
            if (_pies == null)
            {
                InitializedPies();
            }
        }

        //private pie list
        public void InitializedPies()
        {
            _pies = new List<Pie>
            {
                new Pie
                {
                    PieId = 1,
                    Name = "Torta de Maça do Amor!",
                    Price = 99999m,
                    ShortDescription ="Nossa famosa torta de Maça do Amor :P!",
                    LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere!",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg",
                    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg",
                    IsPieOfTheWeek = false
                },
                new Pie
                {
                    PieId = 2,
                    Name = "Torta de Pimenta!",
                    Price = 0.999m,
                    ShortDescription ="Nossa famosa torta de Pimenta hahaha!",
                    LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere!",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecake.jpg",
                    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecakesmall.jpg",
                    IsPieOfTheWeek = false
                }
            };
        }

        //method que retorna todas as pie
        public IEnumerable<Pie> GetAllPies()
        {
            return _pies;
        }

        //method que retorna pie by id
        public Pie GetPieById(int pieid)
        {
            return _pies.FirstOrDefault(m => m.PieId == pieid);
        }
    }
}
