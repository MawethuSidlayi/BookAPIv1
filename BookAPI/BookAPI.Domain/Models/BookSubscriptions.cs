using System;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.Domain.Models
{
    public class BookSubscriptions: BaseEntity
    {
        public Guid? User_Id { get; set; }
        [Required]
        public int? Book_Id{ get; set; }
    }
}
