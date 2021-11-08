using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggleLib.Entities
{
    public class Books
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PriceCredit { get; set; }
        public int RemainAvailable { get; set; }
    }
}
