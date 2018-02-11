using PieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieApp.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }

        public List<Pie> Pies { get; set; }
    }
}
