using System.IO;

namespace Messerli.IO
{
    /// <summary>
    /// A wrapper around another stream.
    /// The inner stream will not be disposed when the <see cref="BorrowedStream" /> is disposed.
    /// </summary>
    internal sealed class BorrowedStream : Stream
    {
        private readonly Stream _inner;

        public BorrowedStream(Stream inner) => _inner = inner;

        public override bool CanRead => _inner.CanRead;

        public override bool CanSeek => _inner.CanSeek;

        public override bool CanWrite => _inner.CanWrite;

        public override long Length => _inner.Length;

        public override long Position
        {
            get => _inner.Position;
            set => _inner.Position = value;
        }

        public override void Flush() => _inner.Flush();

        public override int Read(byte[] buffer, int offset, int count) => _inner.Read(buffer, offset, count);

        public override long Seek(long offset, SeekOrigin origin) => _inner.Seek(offset, origin);

        public override void SetLength(long value) => _inner.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count) => _inner.Write(buffer, offset, count);
    }
}
