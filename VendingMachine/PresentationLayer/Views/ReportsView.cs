using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    internal class ReportsView : DisplayBase, IReportsView
    {
        public void AskForPeriodOfTime()
        {
            Display("You need to enter the start date and end date.(yyyy/MM/dd/HH/mm/ss)\n", color: ConsoleColor.Cyan);
        }

        public DateTime AskForStartDate()
        {
            Display("\nStart date:", color: ConsoleColor.Cyan);
            string startDateReader = Console.ReadLine();
            if (!IsDate(startDateReader))
            {
                do
                {
                    Display("Format date incorrect!!!\nTry Again!(This is the correct format yyyy/MM/dd/HH/mm/ss)", color: ConsoleColor.Red);
                    Display("\nStart date:", color: ConsoleColor.Cyan);
                    startDateReader = Console.ReadLine();
                } while (!IsDate(startDateReader));
            }
            DateTime startDate = Convert.ToDateTime(startDateReader);
            return startDate;
        }

        public DateTime AskForEndDate()
        {
            Display("\nEnd date:", color: ConsoleColor.Cyan);
            string endDateReader = Console.ReadLine();
            if (!IsDate(endDateReader))
            {
                do
                {
                    Display("Format date incorrect!!!\nTry Again!(This is the correct format yyyy/MM/dd/HH/mm/ss)", color: ConsoleColor.Red);
                    Display("\nEnd date:", color: ConsoleColor.Cyan);
                    endDateReader = Console.ReadLine();
                } while (!IsDate(endDateReader));
            }
            DateTime endDate = Convert.ToDateTime(endDateReader);
            
            return endDate;
        }

        public void DisplayDoneWithGetReport()
        {
            Display("Your report was created with successful!", color: ConsoleColor.Green);
        }

        public string DisplayCurrentDateTime()
        {
            DateTimeOffset currentDate = DateTimeOffset.Now;
            return currentDate.ToString("yyyy MM dd HHmmss");
        }

        private bool IsDate(string date)
        {
            DateTime fromDateValue;
            var formats = new[] { "yyyy/MM/dd/HH/mm/ss", "yyyy/MM/dd", "yyyy/MM"};
            if (DateTime.TryParseExact(date, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
    }
}
