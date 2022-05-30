﻿using Ninject;
using PeopleViewer.Common;
using PersonDataReader.Decorators;
using PersonDataReader.Service;
using System.Windows;

namespace PeopleViewer
{
    public partial class App : Application
    {
        IKernel Container = new StandardKernel();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Title = "With DI - Ninject";
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            Container.Bind<IPersonReader>().To<CachingReader>()
                .InSingletonScope()
                .WithConstructorArgument<IPersonReader>(Container.Get<ServiceReader>());
        }

        private void ComposeObjects()
        {
            Current.MainWindow = Container.Get<PeopleViewerWindow>();
        }
    }
}
