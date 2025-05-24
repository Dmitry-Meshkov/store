using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 12312-31231", "D. Knuth", "Art of programming", "A foundational multi-volume work that explores algorithms, data structures, and mathematical techniques with deep theoretical insights and practical rigor. A classic for serious computer scientists.",
                7.19m),
            new Book(2, "ISBN 12312-31232", "M. Fowler", "Refactoring", "A practical guide to improving existing code by applying small, systematic changes that enhance readability, maintainability, and design—essential for clean, agile development.", 
                12.45m),
            new Book(3, "ISBN 12312-31233", "B. Kernighan", "C programming language", "The definitive introduction to the C language, co-authored by its creator. It combines concise explanations with practical examples, serving as both a tutorial and a reference.", 
                14.98m)
        };

		public Book[] GetAllByIds(IEnumerable<int> bookIds)
		{
			var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;
            
            return foundBooks.ToArray();
		}

		public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(x => x.Isbn == isbn)
                        .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Title.Contains(query)
                                    || book.Author.Contains(query))
                        .ToArray();
        }

		public Book GetById(int id)
		{
			return books.Single(book => book.Id == id);
		}
	}
}
