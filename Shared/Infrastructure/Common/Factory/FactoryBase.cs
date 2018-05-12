using Shared.Infrastructure.Common.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Common.Factory
{
    public abstract class FactoryBase
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryBase"/> class.
        /// </summary>
        protected FactoryBase()
        {
        }

        #endregion

        /// Gets the assemblies source output bin path.
        /// </summary>
        /// <returns></returns>
        protected string GetAssembliesSourceOutputBinPath()
        {
            string pathToProbe = System.AppDomain.CurrentDomain.BaseDirectory;
            string pathToCheck = string.Empty;

            bool isPathFound = false;
            while (!isPathFound)
            {
                DirectoryInfo dInfo = Directory.GetParent(pathToProbe);
                if (dInfo != null)
                {
                    pathToProbe = dInfo.FullName;
                    pathToCheck = pathToProbe + "\\" + AppSettings.Instance.OutbinFolderName;

                    if (Directory.Exists(pathToCheck))
                    {
                        isPathFound = true;
                    }
                }
                else
                {
                }
            }

            return pathToCheck + Path.DirectorySeparatorChar;
        }
    }
}
