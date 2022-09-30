using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace iQuest.VendingMachine.DataAccess.Reports
{
    [XmlRoot("VolumeReport")]
    public class VolumeReport
    {
        public DateTime StarDate { get; set; }

        public DateTime EndDate { get; set; }

        [XmlArrayItem("Product")]
        public List<Report> Sales { get; set; }
    }
}
