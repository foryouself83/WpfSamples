using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CoreSamples.Services;
using CoreSamples.Services.Impl;
using Microsoft.Extensions.DependencyInjection;
using TemplateSamples.ViewModels;
using TemplateSamples.Views;
using WpfSamples.ViewModels;

namespace WpfSamples
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Dispatcher.UnhandledExceptionFilter += Dispatcher_UnhandledExceptionFilter;
            Dispatcher.UnhandledException += Dispatcher_UnhandledException;

            TaskScheduler.UnobservedTaskException += UnobservedTaskExceptionHandler;
        }

        /// <summary>
        /// task(async) Exception
        /// https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.taskscheduler.unobservedtaskexception?view=net-8.0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnobservedTaskExceptionHandler(object? sender, UnobservedTaskExceptionEventArgs e)
        {
        }

        /// <summary>
        /// Dispatcher(UI) Exception
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatcher.unhandledexceptionfilter?view=windowsdesktop-8.0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// Dispatcher(UI) Exception Filter
        /// https://learn.microsoft.com/en-us/dotnet/api/system.appdomain.unhandledexception?view=net-8.0#system-appdomain-unhandledexception
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dispatcher_UnhandledExceptionFilter(object sender, DispatcherUnhandledExceptionFilterEventArgs e)
        {
            // true 설정할 경우 프로그램이 종료되지 않으며
            // UnhandledException event가 실행된다.
            e.RequestCatch = true;
        }

        /// <summary>
        /// app.xaml에서 StartUp을 사용하지 않을 경우 사용 가능
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            // 생성될때마다 새로 생성
            services.AddTransient<TemplateView>();
            services.AddTransient<TemplateViewModel>();
            services.AddTransient<NavigationSampleView>();
            services.AddTransient<NavigationSampleViewModel>();

            var service = new ServiceRegister();
            // 한번만 생성
            services.AddSingleton<IServiceRegister>(service);
            services.AddSingleton<INavigationService>(new NavigationService(service));
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowModel>();

            // Service 생성
            //ServiceRegister.Instance.BulidService(services);
            service.BulidService(services);

            var mainWindow = service.GetService<MainWindow>();
            //var mainWindow = ServiceRegister.Instance.GetService<MainWindow>();
            //var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
