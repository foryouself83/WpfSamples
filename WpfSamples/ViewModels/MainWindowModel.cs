using CoreSamples.Services;
using CoreSamples.Viewmodels.Impl;
using TemplateSamples.ViewModels;
using TemplateSamples.ViewModels.Ribbons;

namespace WpfSamples.ViewModels
{
    internal partial class MainWindowModel : ViewmodelBase
    {
        public MainWindowModel(IRibbonMenuService ribbonMenuService, INavigationService navigationService, IEventBrokerService eventBrokerService) : base(ribbonMenuService, navigationService, eventBrokerService)
        {
            ribbonMenuService.UpdateRibbon<TemplateRibbonViewModel>();
            navigationService.NavigateTo<TemplateViewModel>(); ;
        }
    }
}
