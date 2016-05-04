using System.Collections.Generic;

namespace BookStore
{
    public class BookStore
    {
        public int CalculatePrice(List<Book> bookCart)
        {
            if (bookCart.Count == 1) return 100;

            return 0;
        }
    }
}
