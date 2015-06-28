using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOEChat.Server.Core.Infrastructure
{
    public interface IConfigurationSettingsProvider
    {
        string DefaultCulture { get; }
        string LogFilePath { get; }
        string InputFilePath { get; }
        string OutputFilePath { get; }
    }
}
