using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Facade
{
    public interface IFacadeFactory
    {
        T Create<T>(params object[] args) where T : IFacade;
       
    }
}
