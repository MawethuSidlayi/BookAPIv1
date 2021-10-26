using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Domain.Models
{
    public class Book: BaseEntity
    {

        public string Name { get; set; }
        public string Text { get; set; }
        public string PurchasePrice { get; set; }
        
    }
}
