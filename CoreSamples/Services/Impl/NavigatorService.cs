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
        /// <summary>
        /// 등록된 service를 불러오기 위한 service
        /// </summary>
        private readonly IServiceRegister _serviceRegistery;
        /// <summary>
        /// View Push, Pop을 위한 Stack
        /// </summary>
        private readonly Stack<object> _views;

        /// <summary>
        /// 사용 중인 view
        /// </summary>
        [ObservableProperty]
        public object? _currentView;


        public NavigationService(IServiceRegister serviceRegistery)
        {
            this._serviceRegistery = serviceRegistery;
            _views = new Stack<object>();
        }

        public void NavigateTo<TView>() where TView : class
        {
            _views.Clear();
            CurrentView = _serviceRegistery.GetService<TView>();
        }


        public object Push<TView>() where TView : class
        {
            var view = _serviceRegistery.GetService<TView>();
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
