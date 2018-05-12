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

namespace Shared.Infrastructure.Facade
{
    [Synchronization]
    public class FacadeFactory : FactoryBase, IFacadeFactory
    {
        public T Create<T>(params object[] args) where T : IFacade
        {
            string interfaceName  = typeof(T).ToString();
            string className = AppSettings.Instance[interfaceName];

            Assembly assembly = Assembly.LoadFrom(Path.Combine(GetAssembliesSourceOutputBinPath(), AppSettings.Instance.FacadeDLLName));
            return (T)assembly.CreateInstance(className, true);
        }

        #region Singleton

        private FacadeFactory()
        {

        }

        private static FacadeFactory _inst;

        
        public static FacadeFactory Instance
        {
            get
            {
                if (_inst == null)
                {
                    _inst = new FacadeFactory();
                }

                return _inst;
            }
        }

        #endregion
    }
}
