using System;

namespace iQuest.VendingMachine.VendingMachineException
{
    public class InsufficientStockException : Exception
    {

        public InsufficientStockException(string message) : base(message)
        {

        }
    }
}
