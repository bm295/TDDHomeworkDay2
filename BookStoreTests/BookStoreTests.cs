using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStore.Tests
{
    [TestClass()]
    public class BookStoreTests
    {
        [TestMethod()]
        public void CalculatePriceTest_Buy1Book_PriceShouldBe100()
        {
            var bookstore = new BookStore();
            var expected = 100;
            var numberOfBook = 1;

            var actual = bookstore.CalculatePrice(numberOfBook);
            Assert.AreEqual(expected, actual);
        }
    }
}
