namespace CoreSamples.Services
{
    public interface INavigationService
    {
        /// <summary>
        /// ServiceRegister에 등록된 TViewModel 가져와서 반환
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns></returns>
        public void NavigateTo<TViewModel>() where TViewModel : class;

        /// <summary>
        /// Stack ViewModel를 추가하고 해당 ViewModel 반환
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns></returns>
        public object Push<TViewModel>() where TViewModel : class;

        /// <summary>
        /// Stack 추가된 ViewModel를 제거하고 이전 ViewModel를 반환
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <returns></returns>
        object Pop();

        /// <summary>
        /// 현재 Stack 최상단에 있는 ViewModel를 반환
        /// </summary>
        /// <returns></returns>
        public object Peek();

        /// <summary>
        /// Clear Stack 
        /// </summary>
        void Clear();
    }
}
