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
        public void NavigateTo<TView>() where TView : class;

        /// <summary>
        /// Stack View를 추가하고 해당 View를 반환
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <returns></returns>
        public object Push<TView>() where TView : class;

        /// <summary>
        /// Stack 추가된 view를 제거하고 이전 View를 반환
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <returns></returns>
        object Pop();

        /// <summary>
        /// 현재 Stack 최상단에 있는 view를 반환
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <returns></returns>
        public object Peek();

        /// <summary>
        /// Clear Stack 
        /// </summary>
        void Clear();
    }
}
