using CommunityToolkit.Mvvm.ComponentModel;

namespace CoreSamples.Services.Impl
{
    public partial class RibbonMenuService : ObservableObject, IRibbonMenuService
    {
        /// <summary>
        /// 등록된 service를 불러오기 위한 service
        /// </summary>
        private readonly IServiceRegister _serviceRegistery;

        /// <summary>
        /// 사용 중인 view
        /// </summary>
        [ObservableProperty]
        public object? _currentRibbonView;
        public RibbonMenuService(IServiceRegister serviceRegistery)
        {
            this._serviceRegistery = serviceRegistery;
        }

        public void UpdateRibbon<TRibbonViewModel>() where TRibbonViewModel : class
        {
            CurrentRibbonView = _serviceRegistery.GetService<TRibbonViewModel>();
        }
    }
}
