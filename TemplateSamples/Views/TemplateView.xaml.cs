using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoreSamples.Services.Impl;
using TemplateSamples.ViewModels;

namespace TemplateSamples.Views
{
    /// <summary>
    /// TemplateView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TemplateView : UserControl
    {
        public TemplateView()
        {
            InitializeComponent();
            // DataContext에 Service에서 불러온 Viewmodel을 삽입
            this.DataContext = ServiceRegister.Instance.GetService<TemplateViewModel>();
        }
    }
}
