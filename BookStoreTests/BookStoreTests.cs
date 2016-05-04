using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStore.Tests
{
    [TestClass()]
    public class BookStoreTests
    {
        [TestMethod()]
        public void CalculatePriceTest()
        {
            var bookstore = new BookStore();
            var expected = 0;

            var actual = bookstore.CalculatePrice();
            Assert.AreEqual(expected, actual);
        }
    }
}
