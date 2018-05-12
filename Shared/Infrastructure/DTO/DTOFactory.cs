using Shared.Infrastructure.Common.Constants;
using Shared.Infrastructure.Common.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.DTO
{
    [Synchronization]
    public class DTOFactory : FactoryBase, IDTOFactory
    {
        public T Create<T>(params object[] args) where T : IDTO
        {
            string interfaceName = typeof(T).ToString();
            string className = AppSettings.Instance[interfaceName];

            Assembly assembly = Assembly.LoadFrom(Path.Combine(GetAssembliesSourceOutputBinPath(), AppSettings.Instance.DTODllName));
            return (T)assembly.CreateInstance(className, true);
        }

        #region Singleton

        private DTOFactory()
        {

        }

        private static DTOFactory _inst;

        
        public static DTOFactory Instance
        {
            
            get
            {
                if (_inst == null)
                {
                    _inst = new DTOFactory();
                }

                return _inst;
            }
        }

        #endregion
    }
}
