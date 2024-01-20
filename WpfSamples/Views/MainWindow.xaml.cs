using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CoreSamples.Services;
using WpfSamples.ViewModels;

namespace WpfSamples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IServiceRegister serviceRegistery)
        {
            InitializeComponent();
            // DataContext에 Service에서 불러온 Viewmodel을 삽입
            this.DataContext = serviceRegistery.GetService<MainWindowModel>();
        }
    }
}
