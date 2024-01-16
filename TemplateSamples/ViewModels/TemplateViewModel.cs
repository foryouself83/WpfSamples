using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreSamples.Services;
using CoreSamples.Viewmodels.Impl;
using TemplateSamples.Models;

namespace TemplateSamples.ViewModels
{
    public class TemplateViewModel : ViewmodelBase
    {
        public ObservableCollection<TemplateItem> Items { get; set; }
        public TemplateViewModel(INavigationService navigationService) : base(navigationService)
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
        }
    }
}
