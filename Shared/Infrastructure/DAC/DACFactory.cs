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

namespace Shared.Infrastructure.DAC
{
    [Synchronization]
    public class DACFactory : FactoryBase, IDACFactory
    {
        public T Create<T>(params object[] args) where T : IDAC
        {
            string interfaceName = typeof(T).ToString();
            string className = AppSettings.Instance[interfaceName];

            Assembly assembly = Assembly.LoadFrom(Path.Combine(GetAssembliesSourceOutputBinPath(), AppSettings.Instance.DACDllName));
            return (T)assembly.CreateInstance(className, true);
        }

        #region Singleton

        private DACFactory()
        {

        }

        private static DACFactory _inst;

        public static DACFactory Instance
        {
            get
            {
                if (_inst == null)
                {
                    _inst = new DACFactory();
                }

                return _inst;
            }
        }

        #endregion
    }
}
