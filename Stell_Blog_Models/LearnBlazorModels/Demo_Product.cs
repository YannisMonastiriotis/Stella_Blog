using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stell_Blog_Models.LearnBlazorModels
{
    public class Demo_Product
    {
        public int Id { get; set; }

        public double Price { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
