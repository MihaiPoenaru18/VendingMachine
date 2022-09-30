using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using VendingMachine.Business.UseCases.Reports;

namespace iQuest.VendingMachine.Serialize
{
    internal class ReportXmlSerializer : IFileSerializer
    {
        private readonly string reportType;
        private readonly string zipPath;
        private readonly string reportPath;

        public ReportXmlSerializer(string reportType, string zipPath, string reportPath)
        {
            this.reportType = reportType;
            this.zipPath = zipPath;
            this.reportPath = reportPath;
        }

        public void Serilizer(object obj, string reportName)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (var stream = new ZippedReportFileStream(zipPath, reportPath, reportName, reportType))
            {
                using (StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8))
                {
                    using (XmlWriter xmlWriter = new XmlTextWriter(streamWriter) { Indentation = 4 })
                    {
                        serializer.Serialize(stream, obj);
                    }
                }
            }
        }

    }
}