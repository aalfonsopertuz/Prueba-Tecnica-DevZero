using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity
{
    public class Author
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
