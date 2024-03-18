namespace CoreSamples.Services
{
    public interface IRibbonMenuService
    {
        /// <summary>
        /// ServiceRegister에 등록된 TViewModel를 가져와서 반환
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns></returns>
        public void UpdateRibbon<TViewModel>() where TViewModel : class;
    }
}
