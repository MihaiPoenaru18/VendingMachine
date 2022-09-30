using System;
using System.Collections.Generic;
using iQuest.VendingMachine.PresentationLayer.Commands;
using iQuest.VendingMachine.PresentationLayer.Views;
using iQuest.VendingMachine.VendingMachineException;
using System.Linq;

namespace iQuest.VendingMachine
{
    internal class VendingMachineApplication : IVendingMachineApplication
    {
        private readonly IEnumerable<ICommand> commands;
        private readonly IMainView mainView;

        public VendingMachineApplication(IEnumerable<ICommand> commands, IMainView mainView)
        {
            this.commands = commands ?? throw new ArgumentNullException(nameof(commands));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
        }

        public void Run()
        {
            mainView.DisplayApplicationHeader();
            while (true)
            {
                try
                {
                    IEnumerable<ICommand> availableCommands = commands.Where(x => x.CanExecute);
                    ICommand command = mainView.ChooseCommand(availableCommands);
                    command.Execute();
                }

                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidColumnException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InsufficientStockException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidCardNumber ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (CancelExeption ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}