using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Xunit;

namespace Messerli.IO.Test
{
    public sealed class BorrowedStreamTest
    {
        [Fact]
        [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP001", Justification = "Stream is intentionally not disposabl")]
        public void InnerStreamIsNotDisposed()
        {
            using var stream = new MockStream();
            stream.Borrow().Dispose();
            Assert.False(stream.IsDisposed);
        }

        private sealed class MockStream : MemoryStream
        {
            public bool IsDisposed { get; private set; } = false;

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                IsDisposed = true;
            }
        }
    }
}
