using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CoreSamples.Viewmodels;

namespace CoreSamples.Services.Impl
{
    public partial class NavigationService : ObservableObject, INavigationService
    {
        private readonly IServiceRegister serviceRegistery;
        private readonly Stack<object> _views;

        [ObservableProperty]
        public object? _currentView;


        public NavigationService(IServiceRegister serviceRegistery)
        {
            this.serviceRegistery = serviceRegistery;
            _views = new Stack<object>();
        }

        public void NavigateTo<TView>() where TView : class
        {
            _views.Clear();
            CurrentView = serviceRegistery.GetService<TView>();
        }


        public object Push<TView>() where TView : class
        {
            var view = serviceRegistery.GetService<TView>();
            if (CurrentView is null)
            {
                CurrentView = view;
            }
            else
            {
                _views.Push(CurrentView);
                CurrentView = view;
            }
            return view;
        }
        public object Pop()
        {
            if (_views.TryPop(out var view))
            {
                CurrentView = view;
                return view;
            }

            return Peek();
        }

        public object Peek()
        {
            if (!_views.Any() && CurrentView is not null)
                return CurrentView;

            return _views.Peek();
        }

        public void Clear()
        {
            _views.Clear();
        }
    }
}
