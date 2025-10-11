namespace BookLibraryMVC.Models
{
        public class BookModel
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public decimal Price { get; set; }
            public int PublishedYear { get; set; }
        }
}

