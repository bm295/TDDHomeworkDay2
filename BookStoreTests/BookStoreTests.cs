using BookStore;
using System;
using System.Collections.Generic;
using Xunit;

namespace BookStoreTests
{
    public class BookStoreTests
    {
        private BookStoreEngine _Bookstore;
        private List<Book> _BookCart;

        public BookStoreTests()
        {
            _Bookstore = new BookStoreEngine();
            _BookCart = new List<Book>();
        }

        [Fact]
        public void CalculatePriceTest_Buy1Book_PriceShouldBe100()
        {
            _BookCart = new List<Book>
            {
                new Book {Id = 1, Price = 100}
            };

            var actual = _Bookstore.CalculatePrice(_BookCart);

            var expected = 100;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatePriceTest_Buy_2_Book1_PriceShould_200()
        {
            _BookCart = new List<Book>
            {
                new Book {Id = 1, Price = 100},
                new Book {Id = 1, Price = 100}
            };

            var actual = _Bookstore.CalculatePrice(_BookCart);

            var expected = 200;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatePriceTest_BuyBook1AndBook2_ShouldGet5PercentDiscount()
        {
            _BookCart = new List<Book>
            {
                new Book {Id = 1, Price = 100},
                new Book {Id = 2, Price = 100}
            };

            var actual = _Bookstore.CalculatePrice(_BookCart);

            var expected = 190;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatePriceTest_Buy_3_Book1_PriceShould_300()
        {
            _BookCart = new List<Book>
            {
                new Book {Id = 1, Price = 100},
                new Book {Id = 1, Price = 100},
                new Book {Id = 1, Price = 100}
            };

            var actual = _Bookstore.CalculatePrice(_BookCart);

            var expected = 300;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatePriceTest_Buy_2_Book1_And_1_Book2_PriceShould_290()
        {
            _BookCart = new List<Book>
            {
                new Book {Id = 1, Price = 100},
                new Book {Id = 1, Price = 100},
                new Book {Id = 2, Price = 100}
            };

            var actual = _Bookstore.CalculatePrice(_BookCart);

            var expected = 290;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatePriceTest_Buy_Book1_Book2_Book3_Should_10Percent_Discount()
        {
            _BookCart = new List<Book>
            {
                new Book {Id = 1, Price = 100},
                new Book {Id = 2, Price = 100},
                new Book {Id = 3, Price = 100}
            };

            var actual = _Bookstore.CalculatePrice(_BookCart);

            var expected = 270;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatePriceTest_Buy_4_Book1_PriceShould_400()
        {
            _BookCart = new List<Book>
            {
                new Book {Id = 1, Price = 100},
                new Book {Id = 1, Price = 100},
                new Book {Id = 1, Price = 100},
                new Book {Id = 1, Price = 100}
            };

            var actual = _Bookstore.CalculatePrice(_BookCart);

            var expected = 400;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatePriceTest_Buy_1_Book1_And_Book1_Book2_Book3_PriceShould_370()
        {
            _BookCart = new List<Book>
            {
                new Book {Id = 1, Price = 100},
                new Book {Id = 1, Price = 100},
                new Book {Id = 2, Price = 100},
                new Book {Id = 3, Price = 100}
            };

            var actual = _Bookstore.CalculatePrice(_BookCart);

            var expected = 370;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatePriceTest_Buy_4_Different_Books_Should_20Percent_Discount()
        {
            _BookCart = new List<Book>
            {
                new Book {Id = 1, Price = 100},
                new Book {Id = 2, Price = 100},
                new Book {Id = 3, Price = 100},
                new Book {Id = 4, Price = 100}
            };

            var actual = _Bookstore.CalculatePrice(_BookCart);

            var expected = 320;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatePriceTest_Buy_5_Different_Books_Should_25Percent_Discount()
        {
            _BookCart = new List<Book>
            {
                new Book {Id = 1, Price = 100},
                new Book {Id = 2, Price = 100},
                new Book {Id = 3, Price = 100},
                new Book {Id = 4, Price = 100},
                new Book {Id = 5, Price = 100}
            };

            var actual = _Bookstore.CalculatePrice(_BookCart);

            var expected = 375;
            Assert.Equal(expected, actual);
        }
    }
}
