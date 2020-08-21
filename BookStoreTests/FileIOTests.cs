using BookStore;
using System;
using Xunit;

namespace BookStoreTests
{
    public class FileIOTests
    {
        [Fact]
        public void FileIOTest_EmptyFilePath_ShouldThrowException()
        {
            FileIO fileIO = new FileIO();
            Action act = () => fileIO.ReadSpecificLine(string.Empty, 0);
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal("Invalid File Path", exception.Message);
        }
    }
}
