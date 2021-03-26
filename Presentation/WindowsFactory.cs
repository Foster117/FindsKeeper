using Model.Application.Finds;
using Presentation.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;

namespace Presentation
{
    public class WindowsFactory
    {
        public Window CreateWindow(object dataContext)
        {
            switch (dataContext.GetType())
            {
                case Type contextType when contextType == typeof(FindOwerviewWindowViewModel):
                    return new FindOverviewWindow();
                case Type contextType when contextType == typeof(RegistrationWindowViewModel):
                    return new RegistrationWindow();

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
