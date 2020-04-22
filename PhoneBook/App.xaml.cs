using Ninject;
using PhoneBook.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneBook
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
            base.OnStartup(e);
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();
            container.Bind<IRepository<Contact>>().To<SqliteRepository>();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this.container.Get<MainWindow>();
            Current.MainWindow.Title = "Task";
        }
    }
}
