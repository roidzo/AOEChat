using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AOEChat.Server.Core.Infrastructure
{
    public class ConfigurationSettingsProvider : IConfigurationSettingsProvider
    {
        private const string DefaultCultureSetting = "DefaultCulture";
        private readonly string _defaultCulture;

        private const string LogFilePathSetting = "LogFilePath";
        private readonly string _logFilePath;

        private const string InputFilePathSetting = "InputFilePath";
        private readonly string _inputFilePath;

        private const string OutputFilePathSetting = "OutputFilePath";
        private readonly string _outputFilePath;


        public ConfigurationSettingsProvider()
        {
            _defaultCulture = ConfigurationManager.AppSettings[DefaultCultureSetting];
            _logFilePath = ConfigurationManager.AppSettings[LogFilePathSetting];
            _inputFilePath = ConfigurationManager.AppSettings[InputFilePathSetting];
            _outputFilePath = ConfigurationManager.AppSettings[OutputFilePathSetting];
        }

        public string DefaultCulture
        {
            get { return _defaultCulture; }
        }

        public string LogFilePath
        {
            get { return _logFilePath; }
        }

        public string InputFilePath
        {
            get { return _inputFilePath; }
        }

        public string OutputFilePath
        {
            get { return _outputFilePath; }
        }

    }

}
