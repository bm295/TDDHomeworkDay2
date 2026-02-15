using BookStore;
using Xunit;

namespace BookStoreTests;

public class BookIdSequenceTests
{
    [Fact]
    public void GetEnumerator_ReturnsExpectedRange()
    {
        var sequence = new BookIdSequence(startId: 10, count: 4);

        var result = sequence.ToList();

        Assert.Equal(new[] { 10, 11, 12, 13 }, result);
    }

    [Fact]
    public void Constructor_WhenCountIsNegative_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new BookIdSequence(startId: 1, count: -1));
    }
}
