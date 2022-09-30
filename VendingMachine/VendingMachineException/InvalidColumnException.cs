using System;

namespace iQuest.VendingMachine.VendingMachineException
{
    public class InvalidColumnException : Exception
    {
        public InvalidColumnException(string message) : base(message)
        {

        }
    }
}
