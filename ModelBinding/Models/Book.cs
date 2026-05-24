

using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class Book
    {
        //[FromQuery]
        public int? BookId { get; set; }

        public string? Author { get; set;  }

        public override string ToString()
        {
            return $"Book object -> Book Id -{BookId}, Author - {Author}";
        }
    }

}
