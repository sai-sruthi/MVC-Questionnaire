using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.DAC
{
    public interface IDACFactory
    {
        T Create<T>(params object[] args) where T : IDAC;
       
    }
}
