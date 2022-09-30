using System.Xml.Serialization;

namespace iQuest.VendingMachine.DataAccess.Reports
{
    [XmlRoot("Product")]
    public class Report
    {
        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}