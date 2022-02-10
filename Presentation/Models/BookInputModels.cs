using Entity;

namespace Presentation.Models
{
    public class BookInputModels
    {
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
