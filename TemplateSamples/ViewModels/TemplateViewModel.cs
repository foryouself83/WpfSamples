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

            eventBrokerService.Subscribe<ChangedFontSizeEvent>(OnChangedFontSizeEvent);
        }

        public void OnChangedFontSizeEvent(ChangedFontSizeEvent e)
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
    }
}
