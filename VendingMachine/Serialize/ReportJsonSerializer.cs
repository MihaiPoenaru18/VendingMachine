using Newtonsoft.Json;
using System.IO;
using System.Text;
using VendingMachine.Business.UseCases.Reports;

namespace iQuest.VendingMachine.Serialize
{
    internal class ReportJsonSerializer : IFileSerializer
    {
        private readonly string reportType;
        private readonly string zipPath;
        private readonly string reportPath;


        public ReportJsonSerializer(string reportType,string zipPath, string reportPath)
        {
            this.zipPath = zipPath;
            this.reportType = reportType;
            this.reportPath = reportPath;
        }
        public void Serilizer(object obj, string reportName)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (var stream = new ZippedReportFileStream(zipPath, reportPath,  reportName, reportType))
            {
                using (StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8))
                {
                    using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter)
                    {
                        Formatting = Formatting.Indented,
                        Indentation = 4
                    })

                    {
                        serializer.Serialize(jsonWriter, obj);
                    }
                }
            }
        }
    }
}
