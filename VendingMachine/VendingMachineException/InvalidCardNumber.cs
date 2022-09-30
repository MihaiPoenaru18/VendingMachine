using System;

namespace iQuest.VendingMachine.VendingMachineException
{
    class InvalidCardNumber : Exception
    {
        public InvalidCardNumber(string message) : base(message)
        {

        }
    }
}
