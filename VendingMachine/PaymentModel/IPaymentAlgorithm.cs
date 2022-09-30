namespace iQuest.VendingMachine.PaymentModel
{
    public interface IPaymentAlgorithm
    {
        public string Name { get;  }

        public void Run(float price);
    }
}
