using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.Input;

using CoreSamples.Events;
using CoreSamples.Services;
using CoreSamples.Viewmodels.Impl;

using TemplateSamples.Models;

namespace TemplateSamples.ViewModels
{
    public partial class TemplateViewModel : ViewmodelBase
    {
        private readonly IEventBrokerService _eventBrokerService;
        public ObservableCollection<TemplateItem> Items { get; set; }
        public TemplateViewModel(IRibbonMenuService ribbonMenuService, INavigationService navigationService, IEventBrokerService eventBrokerService) : base(ribbonMenuService, navigationService, eventBrokerService)
        {
            Items = new ObservableCollection<TemplateItem>
            {
                new Person("You", "Inchon"),
                new Person("Park", "Seoul"),
                new Person("Kim", "Suwon"),
                new Subject("WPF", "Novice", 100000),
                new Subject("WPF", "Advanced Beginner", 200000),
                new Subject("WPF", "Competent", 300000),
                new Subject("WPF", "Proficient", 500000),
            };

            _eventBrokerService = eventBrokerService;

            eventBrokerService.Subscribe<ChangedTemplateEvent>(OnChangedFontSizeEvent);
        }

        public void OnChangedFontSizeEvent(object serder, ChangedTemplateEvent e)
        {

        }

        [RelayCommand]
        public void PrevView()
        {
            NavigationService.Pop();
        }
        [RelayCommand]
        public void NextView()
        {
            NavigationService.Push<NavigationSampleViewModel>();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            _eventBrokerService.UnSubscribe<ChangedTemplateEvent>(OnChangedFontSizeEvent);
        }
    }
}
