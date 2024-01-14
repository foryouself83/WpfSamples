using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CoreSamples.Viewmodels;

namespace CoreSamples.Services.Impl
{
    public class NavigationService : INavigationService
    {
        private readonly Stack<UserControl> _views;

        public NavigationService()
        {
            _views = new Stack<UserControl>();
        }

        public TView NavigateTo<TView>() where TView : UserControl
        {
            return ServiceRegister.Instance.GetService<TView>();
        }


        public TView Push<TView>() where TView : UserControl
        {
            var view = ServiceRegister.Instance.GetService<TView>();
            _views.Push(view);
            return view;
        }
        public TView Pop<TView>() where TView : UserControl
        {
            if (_views.TryPop(out var view))
                return (TView)view;

            throw new InvalidOperationException("view queue is empty.");
        }

        public TView Peek<TView>() where TView : UserControl
        {
            return (TView)_views.Peek();
        }

        public void Clear()
        {
            _views.Clear();
        }
    }
}
