using System.IO;
using System.IO.Compression;

namespace VendingMachine.Business.UseCases.Reports
{
    public class ZippedReportFileStream : Stream
    {
        private Stream inner;
        private FileStream fileStream;
        private ZipArchive zipArchive;
        private ZipArchiveEntry zipArchiveEntry;
        private readonly string zipPath;
        private readonly string reportName;
        private readonly string reportType;
        private readonly string reportpath;

        public ZippedReportFileStream(string zipPath,string reportpath, string reportName, string reportType)
        {
            this.zipPath = zipPath;
            this.reportpath = reportpath;
            this.reportName = reportName;
            this.reportType = reportType;
            OpenFileStream();
        }

        private void OpenFileStream()
        {
            Directory.CreateDirectory(zipPath);
            string filePath = GetZipName();
            fileStream = new FileStream(filePath, FileMode.CreateNew);
            zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create);
            zipArchiveEntry = zipArchive.CreateEntry(reportpath);
            inner = zipArchiveEntry.Open();
        }

        private string GetZipName()
        {
            return Path.Combine(reportpath, reportName);
        }

        public override bool CanRead => inner.CanRead;
        public override bool CanSeek => inner.CanSeek;
        public override bool CanWrite => inner.CanWrite;
        public override long Length => inner.Length;
        public override long Position { get => inner.Position; set => inner.Position = value; }
        public override void Flush() => inner.Flush();
        public override int Read(byte[] buffer, int offset, int count) => inner.Read(buffer, offset, count);
        public override long Seek(long offset, SeekOrigin origin) => inner.Seek(offset, origin);
        public override void SetLength(long value) => inner.SetLength(value);
        public override void Write(byte[] buffer, int offset, int count) => inner.Write(buffer, offset, count);

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                inner?.Dispose();
                zipArchive?.Dispose();
                fileStream?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}