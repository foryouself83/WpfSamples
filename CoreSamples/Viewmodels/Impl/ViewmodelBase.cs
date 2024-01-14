using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CoreSamples.Services;

namespace CoreSamples.Viewmodels.Impl
{
    public partial class ViewmodelBase : ObservableObject, IViewModelBase
    {
        /// <summary>
        /// Navigation을 위한 interface
        /// </summary>
        public INavigationService NavigationService { get; private set; }

        /// <summary>
        /// 상속 받는 모든 ViewModel에서 필요한 interface를 생성자로 삽입
        /// </summary>
        /// <param name="navigationService"></param>
        public ViewmodelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
