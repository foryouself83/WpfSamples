using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreSamples.Services;

namespace CoreSamples.Viewmodels
{
    public interface IViewModelBase
    {
        public INavigationService NavigationService { get; }
    }
}
