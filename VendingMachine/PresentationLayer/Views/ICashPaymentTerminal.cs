namespace iQuest.VendingMachine.PresentationLayer.Views
{
   internal interface ICashPaymentTerminal
    {
        public float AskForMoney();

        public void GiveBackChange(float restOfMoney);
    }
}
