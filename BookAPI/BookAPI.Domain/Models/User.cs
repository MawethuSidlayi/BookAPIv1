using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Domain.Models
{
    public class User : BaseEntity
    {
        public string EmailAdress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
