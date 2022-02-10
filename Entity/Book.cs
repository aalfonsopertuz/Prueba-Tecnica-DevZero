using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Book
    {
        [Key]
        public string Reference { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }

        public string CodeAuthor { get; set; }
        public Author Author { get; set; }

        public string CodePublisher { get; set; }
        public Publisher Publisher { get; set; }

    }
}


/* public string NameAuthor { get; set; }
        public string NamePublisher { get; set; }*/