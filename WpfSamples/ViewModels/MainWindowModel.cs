using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CoreSamples.Services;
using CoreSamples.Viewmodels.Impl;
using TemplateSamples.ViewModels;
using TemplateSamples.Views;

namespace WpfSamples.ViewModels
{
    internal partial class MainWindowModel : ViewmodelBase
    {
        /// <summary>
        /// 선택된 View
        /// Community Toolkit에서 지원하는 ObservableProperty 적용
        /// Public Get; Set; Notification event 등이 자동 적용된다.
        /// </summary>
        [ObservableProperty]
        private object _selectedView;

        public MainWindowModel(INavigationService navigationService) : base(navigationService)
        {
            _selectedView = navigationService.NavigateTo<TemplateView>();
        }
    }
}
