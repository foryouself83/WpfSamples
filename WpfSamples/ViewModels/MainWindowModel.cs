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
        public MainWindowModel(INavigationService navigationService) : base(navigationService)
        {
            navigationService.NavigateTo<TemplateView>(); ;
        }
    }
}
