using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace CoreSamples.Services.Impl
{
    /// <summary>
    /// Service를 등록하고 가져올 수 있는 class
    /// Microsoft.Extensions.DependencyInjection 를 사용하여 serivce를 제공한다.
    /// https://learn.microsoft.com/ko-kr/dotnet/core/extensions/dependency-injection
    /// https://learn.microsoft.com/ko-kr/dotnet/core/extensions/dependency-injection-usage
    /// </summary>
    public class ServiceRegister : IServiceRegister
    {
        /// <summary>
        /// Service 제공을 위한 provider
        /// </summary>
        protected IServiceProvider? serviceProvider { get; private set; }

        public ServiceRegister()
        {
        }

        /// <summary>
        /// ServiceCollection을 Bulid하여 Provider를 생성한다.
        /// </summary>
        /// <param name="services"></param>
        public void BulidService(IServiceCollection services)
        {
            serviceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// 필요한 Service를 가져온다
        /// BulidService를 실행 후에 사용 가능하다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public T GetService<T>() where T : class
        {
            Debug.Assert(serviceProvider is not null);
            if (serviceProvider is null) throw new NullReferenceException(nameof(serviceProvider));

            return serviceProvider.GetRequiredService<T>();
        }
    }
}
