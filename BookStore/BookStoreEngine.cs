using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore
{
    public class BookStoreEngine
    {
        public int CalculatePrice(List<Book> bookCart)
        {
            if (bookCart.Count == 0) return 0;

            var bookPrice = bookCart[0].Price;

            var distinctBooks = bookCart.Select(x => x.Id).Distinct().ToList();

            if (distinctBooks.Count == 1)
                return bookCart.Count * bookPrice;

            var normalBookCount = bookCart.Count - distinctBooks.Count;

            if (distinctBooks.Count == 2)
            {
                return (int)(distinctBooks.Count * bookPrice * 0.95 + normalBookCount * bookPrice);
            }

            if (distinctBooks.Count == 3)
            {
                return (int)(distinctBooks.Count * bookPrice * 0.9 + normalBookCount * bookPrice);
            }

            if (distinctBooks.Count == 4)
            {
                return (int)(distinctBooks.Count * bookPrice * 0.8 + normalBookCount * bookPrice);
            }

            if (distinctBooks.Count == 5)
            {
                return (int)(distinctBooks.Count * bookPrice * 0.75 + normalBookCount * bookPrice);
            }

            return 0;
        }
    }
}
