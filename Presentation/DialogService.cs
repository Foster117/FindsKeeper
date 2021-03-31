using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Model.Application.Finds;
using Presentation.Windows;
using System.Windows;

namespace Presentation
{
    public class DialogService : IDialogService
    {
        private readonly WindowsFactory factory = new WindowsFactory();

        public void OpenWindow(object dataContext)
        {
            Window window = factory.CreateWindow(dataContext);
            window.DataContext = dataContext;

            if (dataContext is IClosable closable)
            {
                closable.CloseAction = window.Close;
            }
            switch (dataContext.GetType())
            {
                case Type contextType when contextType == typeof(RegistrationWindowViewModel):
                    window.ShowDialog();
                    break;
                case Type contextType when contextType == typeof(LoginWindowViewModel):
                    window.ShowDialog();
                    break;
                default:
                    window.Show();
                    break;
            }
        }
    }
}
