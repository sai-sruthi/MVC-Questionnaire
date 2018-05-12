using Shared.Infrastructure.DAC;
using Shared.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.BDC
{
    public abstract class BDCBase: IBDC
    {
        public DTOFactory DTOFactory
        {
            get
            {
                return DTOFactory.Instance;
            }
        }

        public DACFactory DACFactory
        {
            get
            {
                return DACFactory.Instance;
            }
        }
    }
}
