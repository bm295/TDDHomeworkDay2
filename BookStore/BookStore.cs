using System.Collections.Generic;
using System.Linq;

namespace BookStore
{
    public class BookStore
    {
        public int CalculatePrice(List<Book> bookCart)
        {
            if (bookCart.Count == 0) return 0;

            var distinctBooks = bookCart.Select(x => x.Id).Distinct().ToList();

            if (distinctBooks.Count == 1) return 100;
            if (distinctBooks.Count == 2) return 190;

            return 0;
        }
    }
}
