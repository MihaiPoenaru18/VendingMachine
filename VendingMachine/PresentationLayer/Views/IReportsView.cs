using System;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    public interface IReportsView
    {
        void AskForPeriodOfTime();
        DateTime AskForEndDate();
        DateTime AskForStartDate();
        void DisplayDoneWithGetReport();
        string DisplayCurrentDateTime();

    }
}