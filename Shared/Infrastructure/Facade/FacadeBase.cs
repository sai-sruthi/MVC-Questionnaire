using Shared.Infrastructure.BDC;
using Shared.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Facade
{
    public abstract class FacadeBase : IFacade
    {
        public DTOFactory DTOFactory
        {
            get
            {
                return DTOFactory.Instance;
            }
        }

        public BDCFactory BDCFactory
        {
            get
            {
                return BDCFactory.Instance;
            }
        }
    }
}
