using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CoreSamples.Services
{
    public interface IServiceRegister
    {
        public void BulidService(IServiceCollection services);
        public T GetService<T>() where T : class;
    }
}
