using System.IO;

namespace Messerli.IO
{
    public static class StreamExtension
    {
        /// <summary>
        /// Creates a wrapper around this stream. The inner stream will not be disposed when the wrapper stream is disposed.
        /// </summary>
        public static Stream Borrow(this Stream stream) => new BorrowedStream(stream);
    }
}
