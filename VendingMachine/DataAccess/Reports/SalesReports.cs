using System.Collections.Generic;
using System.Xml.Serialization;

namespace iQuest.VendingMachine.DataAccess.Reports
{
    [XmlRoot("SalesReport")]
    public class SalesReports 
    {
       [XmlElement("Sales")]
       public List<SalesReport> Report { get; set; }
    }
}
