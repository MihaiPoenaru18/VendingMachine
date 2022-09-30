using System.Collections.Generic;

namespace iQuest.VendingMachine.DataAccess
{
    internal interface ISalesRepository
    {
        IEnumerable<Sales> GetAllSales();

    } 
}
