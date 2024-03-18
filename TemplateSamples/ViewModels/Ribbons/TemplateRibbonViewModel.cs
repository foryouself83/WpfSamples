using CommunityToolkit.Mvvm.Input;
using CoreSamples.Events;
using CoreSamples.Services;

namespace TemplateSamples.ViewModels.Ribbons
{
    public partial class TemplateRibbonViewModel
    {
        private readonly IEventBrokerService _eventBrokerService;
        public TemplateRibbonViewModel(INavigationService navigationService, IEventBrokerService eventBrokerService)
        {
            _eventBrokerService = eventBrokerService;
        }

        [RelayCommand]
        public void ChangedFontSize()
        {
            _eventBrokerService.Publish(this, new ChangedFontSizeEvent() { FontSize = 11 });
        }
    }
}
