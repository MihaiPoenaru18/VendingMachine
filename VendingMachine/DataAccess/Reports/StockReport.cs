using System.Collections.Generic;
using System.Xml.Serialization;

namespace iQuest.VendingMachine.DataAccess.Reports
{
    [XmlRoot("StockReport")]
    public class StockReport : List<Report>
    {
        public StockReport(IEnumerable<Report> reports) : base(reports)
        {

        }
    }
}
