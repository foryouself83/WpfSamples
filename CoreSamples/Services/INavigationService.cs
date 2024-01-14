using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CoreSamples.Services
{
    public interface INavigationService
    {
        /// <summary>
        /// ServiceRegister에 등록된 TView를 가져와서 반환
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <returns></returns>
        TView NavigateTo<TView>() where TView : UserControl;

        /// <summary>
        /// Stack View를 추가하고 해당 View를 반환
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <returns></returns>
        TView Push<TView>() where TView : UserControl;

        /// <summary>
        /// Stack 추가된 view를 제거하고 이전 View를 반환
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <returns></returns>
        TView Pop<TView>() where TView : UserControl;

        /// <summary>
        /// 현재 Stack 최상단에 있는 view를 반환
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <returns></returns>
        TView Peek<TView>() where TView : UserControl;

        /// <summary>
        /// Clear Stack 
        /// </summary>
        void Clear();
    }
}
