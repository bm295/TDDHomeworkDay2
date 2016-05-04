using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStore.Tests
{
    [TestClass()]
    public class BookStoreTests
    {
        private BookStore _Bookstore;
        private List<Book> _BookCart;

        [TestInitialize]
        public void InitTest()
        {
            _Bookstore = new BookStore();
            _BookCart = new List<Book>();
        }

        [TestMethod()]
        public void CalculatePriceTest_Buy1Book_PriceShouldBe100()
        {
            _BookCart = new List<Book>
            {
                new Book {Id = 1, Price = 100}
            };

            var actual = _Bookstore.CalculatePrice(_BookCart);
            
            var expected = 100;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePriceTest_BuyBook1AndBook2_ShouldGet5PercentDiscount()
        {
            _BookCart = new List<Book>
            {
                new Book {Id = 1, Price = 100},
                new Book {Id = 2, Price = 100}
            };

            var actual = _Bookstore.CalculatePrice(_BookCart);
            
            var expected = 190;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
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
            Assert.AreEqual(expected, actual);
        }
    }
}
