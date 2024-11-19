using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Core.Models
{
    public class UpdateBookInputModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? QTD { get; set; }
        public bool? Available { get; set; }
    }
}
