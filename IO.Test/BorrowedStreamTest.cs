using System.IO;
using Moq;
using Xunit;

namespace Messerli.IO.Test
{
    public sealed class BorrowedStreamTest
    {
        [Fact]
        public void InnerStreamIsNotDisposed()
        {
            var streamMock = new Mock<Stream>();
            streamMock.Object.Borrow().Dispose();
            streamMock.Verify(s => s.Dispose(), Times.Never);
        }
    }
}
