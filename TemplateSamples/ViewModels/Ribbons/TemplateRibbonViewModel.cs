using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

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
            WeakReferenceMessenger.Default.Send(new ChangedTemplateEvent() { Sender = this, FontSize = 20 });
            _eventBrokerService.Publish(this, new ChangedTemplateEvent() { Sender = this, FontSize = 11 });
        }
    }
}
