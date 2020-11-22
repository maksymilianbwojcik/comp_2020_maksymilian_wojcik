using System;
using System.ComponentModel.DataAnnotations;

namespace Utils
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }

        public Book(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}