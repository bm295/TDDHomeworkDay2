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
        }

        [TestMethod()]
        public void CalculatePriceTest_Buy1Book_PriceShouldBe100()
        {
            _BookCart = new List<Book>
            {
                new Book {Id = 1}
            };

            var actual = _Bookstore.CalculatePrice(_BookCart);
            
            var expected = 100;
            Assert.AreEqual(expected, actual);
        }
    }
}
