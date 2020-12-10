using System.ComponentModel.DataAnnotations;

namespace Spa
{
    public class Book
    {
        [Key]
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }

       public Book(string name, string author, string publisher, int year)
       {
           Name = name;
           Author = author;
           Publisher = publisher;
           Year = year;
       }
    }
}