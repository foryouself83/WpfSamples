using CommunityToolkit.Mvvm.ComponentModel;
using CoreSamples.Services;

namespace CoreSamples.Viewmodels.Impl
{
    public partial class ViewmodelBase : ObservableObject, IViewModelBase
    {

        public IRibbonMenuService RibbonMenuService { get; private set; }
        /// <summary>
        /// Navigation을 위한 interface
        /// </summary>
        public INavigationService NavigationService { get; private set; }

        public IEventBrokerService EventBrokerService { get; private set; }

        /// <summary>
        /// 상속 받는 모든 ViewModel에서 필요한 interface를 생성자로 삽입
        /// </summary>
        /// <param name="navigationService"></param>
        public ViewmodelBase(IRibbonMenuService ribbonMenuService, INavigationService navigationService, IEventBrokerService eventBrokerService)
        {
            RibbonMenuService = ribbonMenuService;
            NavigationService = navigationService;
            EventBrokerService = eventBrokerService;
        }
    }
}
