using System;

using CommunityToolkit.Mvvm.ComponentModel;

using CoreSamples.Services;

namespace CoreSamples.Viewmodels.Impl
{
    public partial class ViewmodelBase : ObservableObject, IViewModelBase, IDisposable
    {
        private bool disposedValue;

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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }
        }

        // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
        // ~ViewmodelBase()
        // {
        //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
