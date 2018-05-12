using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.BDC
{
    public interface IBDCFactory
    {
        T Create<T>(params object[] args) where T : IBDC;
       
    }
}
