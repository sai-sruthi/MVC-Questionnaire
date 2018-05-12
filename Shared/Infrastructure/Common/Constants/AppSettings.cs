using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Common.Constants
{
    [Synchronization]
    public class AppSettings
    {
        public string this[string key]
        {
            get
            {
                return ConfigurationManager.AppSettings[key];
            }
        }

        public string OutbinFolderName
        {
            get
            {
                return ConfigurationManager.AppSettings["OutbinFolderName"];
            }
        }

        public string FacadeDLLName
        {
            get
            {
                return ConfigurationManager.AppSettings["FacadeDLLName"];
            }
        }

        public string BDCDllName
        {
            get
            {
                return ConfigurationManager.AppSettings["BDCDllName"];
            }
        }

        public string DACDllName
        {
            get
            {
                return ConfigurationManager.AppSettings["DACDllName"];
            }
        }

        public string DTODllName
        {
            get
            {
                return ConfigurationManager.AppSettings["DTODllName"];
            }
        }

        #region Singleton

        private AppSettings()
        {

        }

        private static AppSettings _inst;

        
        public static AppSettings Instance
        {
            get
            {
                if (_inst == null)
                {
                    _inst = new AppSettings();
                }

                return _inst;
            }
        }

        #endregion
        
    }
}
