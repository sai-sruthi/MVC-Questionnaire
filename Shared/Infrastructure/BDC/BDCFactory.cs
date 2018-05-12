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

namespace Shared.Infrastructure.BDC
{
    [Synchronization]
    public class BDCFactory : FactoryBase, IBDCFactory
    {
        public T Create<T>(params object[] args) where T : IBDC
        {
            string interfaceName = typeof(T).ToString();
            string className = AppSettings.Instance[interfaceName];


            Assembly assembly = Assembly.LoadFrom(Path.Combine(GetAssembliesSourceOutputBinPath(), AppSettings.Instance.BDCDllName));
            return (T)assembly.CreateInstance(className, true);
        }

        #region Singleton

        private BDCFactory()
        {

        }

        private static BDCFactory _inst;


        public static BDCFactory Instance
        {
            get
            {
                if (_inst == null)
                {
                    _inst = new BDCFactory();
                }

                return _inst;
            }
        }

        #endregion
    }
}
