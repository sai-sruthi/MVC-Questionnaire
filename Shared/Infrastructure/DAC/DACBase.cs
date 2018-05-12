using Shared.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.DAC
{
    public abstract class DACBase: IDAC
    {
        public DTOFactory DTOFactory
        {
            get
            {
                return DTOFactory.Instance;
            }
        }
    }
}
