using System;

namespace iQuest.VendingMachine.VendingMachineException
{
    public class CancelExeption : Exception
    {
        public CancelExeption(string message) : base(message)
        {

        }
    }
}
