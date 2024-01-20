using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CoreSamples.Services;
using TemplateSamples.ViewModels;

namespace TemplateSamples.Views
{
    /// <summary>
    /// navigationSampleView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NavigationSampleView : UserControl
    {
        public NavigationSampleView(IServiceRegister serviceRegistery)
        {
            InitializeComponent();
            // DataContext에 Service에서 불러온 Viewmodel을 삽입
            this.DataContext = serviceRegistery.GetService<NavigationSampleViewModel>();
        }
    }
}
